namespace LibraryManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            while (true)
            {
                PrintMenu();

                int choice = int.Parse(Console.ReadLine());
                string ISBnumber;

                switch (choice)
                {
                    case 1:
                        var newBook = AddBook();
                        if (SearchBookByISBN(newBook.ISBN, books) != null)
                        {
                            Console.WriteLine("Book with ISBN " + newBook.ISBN + " already exists in the library");
                            break;
                        }
                        books.Add(newBook);
                        Console.WriteLine("New book with title " + newBook.Title + " with author " + newBook.Author + " with ISBN " + newBook.ISBN + " is available in the library by " + newBook.AvailableCopies + " copies from total of " + newBook.TotalCopies + " copies added successfully to the library.");
                        break;
                    case 2:
                        ViewBooks(books);
                        break;
                    case 3:
                        ISBnumber = getInput("Enter ISBN number: ");
                        Book currBook = SearchBookByISBN(ISBnumber, books);
                        if (currBook != null)
                        {
                            Console.WriteLine("Book " + currBook.Title + " with author " + currBook.Author + " with ISBN " + currBook.ISBN + " is available in the library by " + currBook.AvailableCopies + " copies from total of " + currBook.TotalCopies + " copies.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found!");
                        }
                        break;
                    case 4:
                        ISBnumber = getInput("Enter ISBN number: ");
                        CheckoutBook(ISBnumber, books);
                        break;
                    case 5:
                        ISBnumber = getInput("Enter ISBN number: ");
                        ReturnBook(ISBnumber, books);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void ReturnBook(string ISBN, List<Book> books)
        {
            Book book = SearchBookByISBN(ISBN, books);
            if (book != null)
            {
                if (book.AvailableCopies == book.TotalCopies)
                {
                    Console.WriteLine("All copies of the book are already in the library");
                    return;
                }

                book.AvailableCopies++;
                Console.WriteLine("Book returned successfully");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        private static void CheckoutBook(string ISBN, List<Book> books)
        {
            Book book = SearchBookByISBN(ISBN, books);
            if (book != null)
            {
                if (book.AvailableCopies > 0)
                {
                    book.AvailableCopies--;
                    Console.WriteLine("Book checked out successfully");
                }
                else
                {
                    Console.WriteLine("Book is not available");
                }
            }
            else
            {
                Console.WriteLine("Book not found");
            }

        }

        private static Book SearchBookByISBN(string ISBN, List<Book> books)
        {
            return books.Find(book => book.ISBN == ISBN);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. View library books");
            Console.WriteLine("3. Search book by ISBN");
            Console.WriteLine("4. Checkout book");
            Console.WriteLine("5. Return book");
            Console.WriteLine("6. Exit");
        }

        public static Book AddBook()
        {
            string title = getInput("Enter book name: ");
            string author = getInput("Enter book author: ");
            string ISBN = getInput("Enter book ISBN: ");
            int availableCopies = getNumericalInput("Enter book available copies: ");
            int totalCopies = getNumericalInput("Enter book total copies: ");
            if (availableCopies > totalCopies)
            {
                Console.WriteLine("Available copies cannot be more than total copies");
                totalCopies = getNumericalInput("Enter correct book total copies: ");
            }
            Book book = new Book(title, author, ISBN, availableCopies, totalCopies);
            return book;
        }

        public static bool checkInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }

        public static string getInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (!checkInput(input))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            return input;
        }

        public static int getNumericalInput(string number)
        {
            Console.WriteLine(number);
            string input = Console.ReadLine();
            int output;
            while (!int.TryParse(input, out output))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(number);
                input = Console.ReadLine();
            }
            return output;
        }

        public static void ViewBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the library");
                return;
            }

            Console.WriteLine($"There are total {books.Count} books in the library:");
            foreach (Book book in books)
            {
                Console.WriteLine("Book " + book.Title + " with author " + book.Author + " with ISBN " + book.ISBN + " is available in the library by " + book.AvailableCopies + " copies from total of " + book.TotalCopies + " copies.");
            }
        }
    }

    internal class Book
    {
        private string title;
        private string author;
        private string isbn;
        private int availableCopies;
        private int totalCopies;

        public Book() { }

        public Book(string title, string author, string isbn, int availableCopies, int totalCopies)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.availableCopies = availableCopies;
            this.totalCopies = totalCopies;
        }

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string ISBN { get => isbn; set => isbn = value; }
        public int AvailableCopies { get => availableCopies; set => availableCopies = value; }
        public int TotalCopies { get => totalCopies; set => totalCopies = value; }

        public bool CheckoutBook()
        {
            if (availableCopies > 0)
            {
                availableCopies--;
                return true;
            }
            return false;
        }

        public void ReturnBook()
        {
            availableCopies++;
        }
    }
}

