namespace OnlineBookstoreManagement;

public class Order
{
    private Customer _customer;
    private int _orderId;
    private List<Book> _books = new List<Book>();
    private double _totalPrice;
    private DateTime _orderDate;

    public Customer Customer
    {
        get => _customer;
        set => _customer = value;
    }

    public int OrderId
    {
        get => _orderId;
        set => _orderId = value;
    }

    public List<Book> Books
    {
        get => _books;
        set => _books = value;
    }

    public double TotalPrice
    {
        get => _totalPrice;
        set => _totalPrice = value;
    }

    public DateTime OrderDate
    {
        get => _orderDate;
        set => _orderDate = value;
    }

    public Order(Customer customer, int orderId, List<Book> books, double totalPrice, DateTime orderDate)
    {
        Customer = customer;
        OrderId = orderId;
        Books = books;
        TotalPrice = totalPrice;
        OrderDate = orderDate;
    }

    public override string ToString()
    {
        return $"Customer => {Customer.Name}\nOrder ID: {OrderId} - Total Price: {TotalPrice} / Order Date: {OrderDate}";
    }

    //This code returns Orders List from Orders.txt file
    public static List<Order> GetAllOrders()
    {
        List<Order> orders = new List<Order>();
        string[] ordersString = File.ReadAllLines("Orders.txt");
        foreach (var orderString in ordersString)
        {
            string[] orderDetail = orderString.Split(",");
            int orderId = int.Parse(orderDetail[0]);
            string customerEmail = orderDetail[1];
            List<Book> books = Book.GetAllBooks();
            double totalPrice = double.Parse(orderDetail[2]);
            DateTime orderDate = DateTime.Parse(orderDetail[3]);
            Order order = new Order(Customer.GetCustomerByEmail(customerEmail), orderId, books, totalPrice, orderDate);
            orders.Add(order);
        }

        return orders;
    }

    //This code returns GetLastOrderId from Orders.txt file
    public static int GetLastOrderId()
    {
        string[] ordersString = File.ReadAllLines("Orders.txt");
        if (ordersString.Length == 0)
        {
            return 0;
        }

        string lastOrderString = ordersString[ordersString.Length - 1];
        string[] lastOrderDetail = lastOrderString.Split(",");
        int lastOrderId = int.Parse(lastOrderDetail[0]);
        return lastOrderId;
    }

    //This code Filter orders by Customer or Date from Orders.txt file
    public static void FilterOrders()
    {
        Menu.ShowOrderFilterMenu();
        int option = Validations.CheckIntInput("Enter your choice:");
        switch (option)
        {
            case 1:
                Console.WriteLine("Please enter Customer Email:");
                string customerEmail = Console.ReadLine();
                List<Order> orders = GetAllOrders();
                if (orders.Count == 0)
                {
                    Console.WriteLine("There are no orders in the system");
                }
                foreach (var order in orders)
                {
                    if (order.Customer.Email == customerEmail)
                    {
                        Console.WriteLine(order);
                    }
                }
                break;
            case 2:
                DateTime orderDate = Validations.CheckDateTimeInput("Please enter Order Date:");
                List<Order> orders1 = GetAllOrders();
                if (orders1.Count == 0)
                {
                    Console.WriteLine("There are no orders in the system");
                }
                foreach (var order in orders1)
                {
                    if (order.OrderDate >= orderDate)
                    {
                        Console.WriteLine(order);
                    }
                }
                break;
            case 3:
                return;
        }
    }

    public static void DetailedOrders()
    {
        List<Order> orders = GetAllOrders();
        foreach (var order in orders)
        {
            Console.WriteLine(order);
            var details = OrderDetails.GetAllOrderDetails();
            foreach (var detail in details)
            {
                if (detail.OrderId == order.OrderId)
                {
                    Console.WriteLine(detail);
                }
            }
        }
    }







}