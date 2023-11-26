namespace OnlineBookstoreManagement;

public class Book
{
    private string _title;
    private string _author;
    private string _genre;
    private double _price;
    private int _quantity;

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

    public string Genre
    {
        get => _genre;
        set => _genre = value;
    }

    public double Price
    {
        get => _price;
        set => _price = value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public Book(string title, string author, string genre, double price, int quantity)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nPrice: {Price}\nQuantity: {Quantity}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        Book book = (Book)obj;
        return Title == book.Title && Author == book.Author;
    }

    // This method returns list of all books contained in Books.txt file
    public static List<Book> GetAllBooks()
    {
        List<Book> books = new List<Book>();
        string[] booksString = File.ReadAllLines("Books.txt");
        foreach (var bookString in booksString)
        {
            string[] bookDetail = bookString.Split(",");
            Book book = new Book(bookDetail[0], bookDetail[1], bookDetail[2], double.Parse(bookDetail[3]), int.Parse(bookDetail[4]));
            books.Add(book);
        }

        return books;
    }

    //This method searches for a book by title, author or genre
    public static void SearchBook()
    {
        Menu.ShowSearchMenu();
        int input = Validations.CheckIntInput("Enter your choice:");
        List<Book> books = GetAllBooks();
        switch (input)
        {
            case 1:
                string title = Validations.CheckStringInput("Enter book title:");
                foreach (var book in books)
                {
                    if (book.Title.ToLower().Contains(title.ToLower()))
                    {
                        Console.WriteLine(book);
                    }
                    else
                    {
                        Console.WriteLine("There is no book with this title");
                    }
                }
                break;
            case 2:
                string author = Validations.CheckStringInput("Enter book author:");
                foreach (var book in books)
                {
                    if (book.Author.ToLower().Contains(author.ToLower()))
                    {
                        Console.WriteLine(book);
                    }
                    else
                    {
                        Console.WriteLine("There is no book with this author");
                    }
                }
                break;
            case 3:
                string genre = Validations.CheckStringInput("Enter book genre:");
                foreach (var book in books)
                {
                    if (book.Genre.ToLower().Contains(genre.ToLower()))
                    {
                        Console.WriteLine(book);
                    }
                    else
                    {
                        Console.WriteLine("There is no book with this genre");
                    }
                }
                break;
            case 4:
                return;
        }
    }

    //This method Show Books Quantity report
    public static void ShowBooksQuantityReport()
    {
        List<Book> books = GetAllBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books in the system");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title} - Quantity: {book.Quantity}");
            }
        }
    }

    //This method adds a new book to Books.txt file
    public static void AddBook()
    {
        string title = Validations.CheckStringInput("Enter book title:");
        string author = Validations.CheckStringInput("Enter book author:");
        string genre = Validations.CheckStringInput("Enter book genre:");
        double price = Validations.CheckDoubleInput("Enter book price:");
        int quantity = Validations.CheckIntInput("Enter book quantity:");
        Book book = new Book(title, author, genre, price, quantity);
        List<Book> books = GetAllBooks();
        if (books.Contains(book))
        {
            Console.WriteLine("This book already exists in the system");
        }
        else
        {
            //This code appends the new book to Books.txt file
            File.AppendAllText("Books.txt", $"{book.Title},{book.Author},{book.Genre},{book.Price},{book.Quantity}\n");

            //books.Add(book);
            //File.WriteAllText("Books.txt", String.Empty);
            //foreach (var b in books)
            //{
            //    File.AppendAllText("Books.txt", $"{b.Title},{b.Author},{b.Genre},{b.Price},{b.Quantity}\n");
            //}
            Console.WriteLine("Book added successfully");
        }
    }

    //This method updates a book in Books.txt file
    public static void UpdateBook()
    {
        string title = Validations.CheckStringInput("Enter book title:");
        List<Book> books = GetAllBooks();
        foreach (var book in books)
        {
            if (book.Title.ToLower().Contains(title.ToLower()))
            {
                Menu.ShowUpdateBookMenu();
                int input = Validations.CheckIntInput("Enter your choice:");
                switch (input)
                {
                    case 1:
                        string newTitle = Validations.CheckStringInput("Enter new title:");
                        book.Title = newTitle;
                        break;
                    case 2:
                        string newAuthor = Validations.CheckStringInput("Enter new author:");
                        book.Author = newAuthor;
                        break;
                    case 3:
                        string newGenre = Validations.CheckStringInput("Enter new genre:");
                        book.Genre = newGenre;
                        break;
                    case 4:
                        double newPrice = Validations.CheckDoubleInput("Enter new price:");
                        book.Price = newPrice;
                        break;
                    case 5:
                        int newQuantity = Validations.CheckIntInput("Enter new quantity:");
                        book.Quantity = newQuantity;
                        break;
                    case 6:
                        return;
                }

                File.WriteAllText("Books.txt", String.Empty);
                foreach (var b in books)
                {
                    File.AppendAllText("Books.txt", $"{b.Title},{b.Author},{b.Genre},{b.Price},{b.Quantity}\n");
                }

                Console.WriteLine("Book updated successfully");
                return;
            }
        }

        Console.WriteLine("There is no book with this title");
    }

    //This method deletes a book from Books.txt file
    public static void DeleteBook()
    {
        string title = Validations.CheckStringInput("Enter book title:");
        List<Book> books = GetAllBooks();
        foreach (var book in books)
        {
            if (book.Title.ToLower().Contains(title.ToLower()))
            {
                books.Remove(book);
                File.WriteAllText("Books.txt", String.Empty);
                foreach (var b in books)
                {
                    File.AppendAllText("Books.txt", $"{b.Title},{b.Author},{b.Genre},{b.Price},{b.Quantity}\n");
                }

                Console.WriteLine("Book deleted successfully");
                return;
            }
        }

        Console.WriteLine("There is no book with this title");
    }

    //This method returns list of all books contained in Books.txt file that are below 10 quantity
    public static List<Book> GetBooksBelow10Quantity()
    {
        List<Book> books = new List<Book>();
        string[] booksString = File.ReadAllLines("Books.txt");
        foreach (var bookString in booksString)
        {
            string[] bookDetail = bookString.Split(",");
            Book book = new Book(bookDetail[0], bookDetail[1], bookDetail[2], double.Parse(bookDetail[3]), int.Parse(bookDetail[4]));
            if (book.Quantity < 10)
            {
                books.Add(book);
            }
        }

        return books;
    }
}