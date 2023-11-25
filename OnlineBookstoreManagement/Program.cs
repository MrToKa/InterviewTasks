namespace OnlineBookstoreManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramDatabase.CreateUsersFile();
            ProgramDatabase.CreateBooksFile();
            ProgramDatabase.CreateCustomersFile();
            ProgramDatabase.CreateOrdersFile();
            ProgramDatabase.CreateOrderDetailsFile();

            Console.WriteLine("Welcome to the Online Bookstore Management System!");

            bool isLogin = false;

            while (isLogin == false)
            {
                Menu.LoginMenu();
                int input = Validations.CheckIntInput("Enter your choice:");

                switch (input)
                {
                    case 1:
                        isLogin = Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using Online Bookstore Management System!");
                        return;
                }
            }

            while (isLogin)
            {
                Menu.ShowAdminMenu();
                int input = Validations.CheckIntInput("Enter your choice:");

                switch (input)
                {
                    case 1:
                        var booksList = Book.GetAllBooks();
                        if (booksList.Count == 0)
                        {
                            Console.WriteLine("There are no books in the system");
                        }
                        else
                        {
                            foreach (var book in booksList)
                            {
                                Console.WriteLine(book);
                            }
                        }
                        break;
                    case 2:
                        Book.SearchBook();
                        break;
                    case 3:
                        Book.ShowBooksQuantityReport();
                        break;
                    case 4:
                        Book.AddBook();
                        break;
                    case 5:
                        Book.UpdateBook();
                        break;
                    case 6:
                        Book.DeleteBook();
                        break;
                    case 7:
                        var customersList = Customer.GetAllCustomers();
                        if (customersList.Count == 0)
                        {
                            Console.WriteLine("There are no customers in the system");
                        }
                        else
                        {
                            foreach (var customer in customersList)
                            {
                                Console.WriteLine(customer);
                            }
                        }
                        break;
                    case 8:
                        Customer.SearchCustomer();
                        break;
                    case 9:
                        Customer.AddCustomer();
                        break;
                    case 10:
                        Customer.UpdateCustomer();
                        break;
                    case 11:
                        Customer.DeleteCustomer();
                        break;
                    case 12:
                        Customer.PlaceOrder();
                        break;
                    case 13:
                        var ordersList = Order.GetAllOrders();
                        if (ordersList.Count == 0)
                        {
                            Console.WriteLine("There are no orders in the system");
                        }
                        else
                        {
                            Order.DetailedOrders();
                        }
                        break;
                    case 14:
                        Order.FilterOrders();
                        break;
                    case 15:
                        Console.WriteLine("You have successfully logged out!");
                        isLogin = false;
                        break;
                }
            }
        }

        private static void Register()
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            if (ProgramDatabase.IsUserExist(email, password))
            {
                Console.WriteLine("User already exists");
                return;
            }

            User user = new User(email, password);
            File.AppendAllText("Users.txt", user.ToString());
            Console.WriteLine("User successfully registered!");
        }

        private static bool Login()
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            if (ProgramDatabase.IsUserExist(email, password))
            {
                Console.WriteLine("You have successfully logged in!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid email or password");
                return false;
            }
        }
    }
}