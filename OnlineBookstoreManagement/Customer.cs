namespace OnlineBookstoreManagement;

public class Customer
{
    private string _name;
    private string _email;
    private List<Order> _orders = new List<Order>();

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Email
    {
        get => _email;
        set => _email = value;
    }

    public List<Order> Orders
    {
        get => _orders;
        set => _orders = value;
    }

    public Customer(string name, string email, List<Order> orders)
    {
        Name = name;
        Email = email;
        Orders = orders;
    }

    public override string ToString()
    {
        return $"Name: {Name}\nEmail: {Email}";
    }

    //This code returns Customers List from Customers.txt file
    public static List<Customer> GetAllCustomers()
    {
        List<Customer> customers = new List<Customer>();
        string[] customersString = File.ReadAllLines("Customers.txt");
        foreach (var customerString in customersString)
        {
            string[] customerData = customerString.Split(",");
            string name = customerData[0];
            string email = customerData[1];
            List<Order> orders = new List<Order>();
            customers.Add(new Customer(name, email, orders));
        }

        return customers;
    }

    //This code Search for Customer by Name or Email from Customers.txt file by using ShowSearchCustomerMenu() method
    public static void SearchCustomer()
    {
        Menu.ShowSearchCustomerMenu();
        int option = Validations.CheckIntInput("Please select an option: ");
        switch (option)
        {
            case 1:
                string name = Validations.CheckStringInput("Enter Customer Name:");
                Customer customerByName = GetAllCustomers().First(predicate: customer => customer.Name == name);

                if (customerByName == null)
                {
                    Console.WriteLine("There are no customers with this name");
                }
                else
                {
                    Console.WriteLine(customerByName);
                }

                break;
            case 2:
                Console.WriteLine("Enter Customer Email:");
                string email = Console.ReadLine();
                Customer customerByEmail = GetAllCustomers().First(customer => customer.Email == email);

                if (customerByEmail == null)
                {
                    Console.WriteLine("There are no customers with this email");
                }
                else
                {
                    Console.WriteLine(customerByEmail);
                }

                break;
            case 3:
                break;
        }
    }

    //This code Add new Customer to Customers.txt file
    public static void AddCustomer()
    {
        string name = Validations.CheckStringInput("Enter Customer Name:");
        string email = Validations.CheckStringInput("Enter Customer Email:");
        List<Customer> customers = GetAllCustomers();
        foreach (var customer in customers)
        {
            if (customer.Email == email)
            {
                Console.WriteLine("There is already a customer with this email");
                return;
            }
        }

        Customer newCustomer = new Customer(name, email, new List<Order>());
        customers.Add(newCustomer);
        File.WriteAllText("Customers.txt", string.Empty);
        foreach (var customer in customers)
        {
            File.AppendAllText("Customers.txt", $"{customer.Name},{customer.Email}\n");
        }
    }

    //this code Update Customer Name or Email from Customers.txt file by using ShowUpdateCustomerMenu() method
    public static void UpdateCustomer()
    {
        Menu.ShowUpdateCustomerMenu();
        int option = Validations.CheckIntInput("Please select an option: ");
        switch (option)
        {
            case 1:
                string name = Validations.CheckStringInput("Enter Customer Name:");
                Customer customerByName = GetAllCustomers().First(predicate: customer => customer.Name == name);

                if (customerByName == null)
                {
                    Console.WriteLine("There are no customers with this name");
                }
                else
                {
                    string newName = Validations.CheckStringInput("Enter new Customer Name:");
                    customerByName.Name = newName;
                    File.WriteAllText("Customers.txt", string.Empty);
                    foreach (var customer in GetAllCustomers())
                    {
                        File.AppendAllText("Customers.txt", $"{customer.Name},{customer.Email}\n");
                    }
                }

                break;
            case 2:
                string email = Validations.CheckStringInput("Enter Customer Email:");
                Customer customerByEmail = GetAllCustomers().First(customer => customer.Email == email);

                if (customerByEmail == null)
                {
                    Console.WriteLine("There are no customers with this email");
                }
                else
                {
                    string newEmail = Validations.CheckStringInput("Enter Customer Email:");
                    customerByEmail.Email = newEmail;
                    File.WriteAllText("Customers.txt", string.Empty);
                    foreach (var customer in GetAllCustomers())
                    {
                        File.AppendAllText("Customers.txt", $"{customer.Name},{customer.Email}\n");
                    }
                }

                break;
            case 3:
                break;
        }
    }

    //This code deletes Customer from Customers.txt file
    public static void DeleteCustomer()
    {
        string name = Validations.CheckStringInput("Enter Customer Name:");
        Customer customerByName = GetAllCustomers().First(predicate: customer => customer.Name == name);

        if (customerByName == null)
        {
            Console.WriteLine("There are no customers with this name");
        }
        else
        {
            List<Customer> customers = GetAllCustomers();
            customers.Remove(customerByName);
            File.WriteAllText("Customers.txt", string.Empty);
            foreach (var customer in customers)
            {
                File.AppendAllText("Customers.txt", $"{customer.Name},{customer.Email}\n");
            }
        }
    }

    public static void PlaceOrder()
    {
        string email = Validations.CheckStringInput("Enter Customer Email:");
        Customer customerByEmail = GetAllCustomers().First(customer => customer.Email == email);

        if (customerByEmail == null)
        {
            Console.WriteLine("There are no customers with this email");
        }
        else
        {
            List<Book> books = Book.GetAllBooks();
            List<Book> cart = new List<Book>();
            while (true)
            {
                Menu.ShowCartMenu();
                int option = Validations.CheckIntInput("Enter your choice:");
                switch (option)
                {
                    case 1:
                        Book.ShowBooksQuantityReport();
                        string title = Validations.CheckStringInput("Enter book title:");
                        Book bookByTitle = books.First(book => book.Title == title);

                        if (bookByTitle == null)
                        {
                            Console.WriteLine("There is no book with this title");
                        }
                        else
                        {
                            int quantity = Validations.CheckIntInput("Enter quantity:");
                            if (quantity > bookByTitle.Quantity)
                            {
                                Console.WriteLine("There is not enough quantity in stock");
                            }
                            else
                            {
                                bookByTitle.Quantity -= quantity;
                                cart.Add(new Book(bookByTitle.Title, bookByTitle.Author, bookByTitle.Genre, bookByTitle.Price, quantity));
                                Console.WriteLine("Book added to cart successfully");
                            }
                        }

                        File.WriteAllText("Books.txt", string.Empty);
                        foreach (var book in books)
                        {
                            File.AppendAllText("Books.txt", $"{book.Title},{book.Author},{book.Genre},{book.Price},{book.Quantity}\n");
                        }

                        break;
                    case 2:
                        string title1 = Validations.CheckStringInput("Enter book title:");
                        Book bookByTitle1 = books.First(book => book.Title == title1);

                        if (bookByTitle1 == null)
                        {
                            Console.WriteLine("There is no book with this title");
                        }
                        else
                        {
                            Console.WriteLine("Please enter quantity:");
                            int quantity1 = Validations.CheckIntInput("Enter quantity:");
                            if (quantity1 > bookByTitle1.Quantity)
                            {
                                Console.WriteLine("There is not enough quantity in stock");
                            }
                            else
                            {
                                bookByTitle1.Quantity -= quantity1;
                                if (bookByTitle1.Quantity == 0)
                                {
                                    books.Remove(bookByTitle1);
                                }
                                var bookToReplenish = books.First(book => book.Title == title1);
                                bookToReplenish.Quantity += quantity1;
                            }
                        }

                        File.WriteAllText("Books.txt", string.Empty);
                        foreach (var book in books)
                        {
                            File.AppendAllText("Books.txt", $"{book.Title},{book.Author},{book.Genre},{book.Price},{book.Quantity}\n");
                        }

                        break;
                    case 3:
                        foreach (var book in cart)
                        {
                            Console.WriteLine(book);
                        }
                        break;
                    case 4:
                        Menu.ShowCheckoutMenu();
                        int option1 = Validations.CheckIntInput("Enter your choice:");
                        switch (option1)
                        {
                            case 1:
                                double totalPrice = 0;
                                foreach (var book in cart)
                                {
                                    totalPrice += book.Price * book.Quantity;
                                }
                                Order order = new Order(customerByEmail, Order.GetLastOrderId() + 1, cart, totalPrice, DateTime.Now);
                                List<Order> orders = Order.GetAllOrders();
                                orders.Add(order);
                                File.WriteAllText("Orders.txt", string.Empty);
                                foreach (var order1 in orders)
                                {
                                    File.AppendAllText("Orders.txt", $"{order1.OrderId},{order1.Customer.Email},{order1.TotalPrice},{order1.OrderDate}\n");
                                }
                                

                                List<OrderDetails> orderDetails = OrderDetails.GetAllOrderDetails();
                                foreach (var book in cart)
                                {
                                    orderDetails.Add(new OrderDetails(Order.GetLastOrderId(), book.Title, book.Author, book.Genre,book.Price,  book.Quantity));
                                }
                                File.WriteAllText("OrderDetails.txt", string.Empty);
                                foreach (var book in orderDetails)
                                {
                                    File.AppendAllText("OrderDetails.txt", $"{book.OrderId},{book.Title},{book.Author},{book.Genre},{book.Price},{book.Quantity}\n");
                                }
                                Console.WriteLine("Order placed successfully");


                                return;
                            case 2:
                                break;
                        }
                        break;
                    case 5:
                        return;
                }
            }
        }
    }

    //This code returns Customer by Email from Customers.txt file
    public static Customer GetCustomerByEmail(string email)
    {
        List<Customer> customers = GetAllCustomers();
        foreach (var customer in customers)
        {
            if (customer.Email == email)
            {
                return customer;
            }
        }

        return null;
    }
}