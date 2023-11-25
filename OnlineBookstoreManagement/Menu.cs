namespace OnlineBookstoreManagement;

public class Menu
{
    public static void LoginMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
    }

    public static void ShowAdminMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. View Books List");
        Console.WriteLine("2. Search for Books by Title, Author or Genre");
        Console.WriteLine("3. Show Books Quantity report");
        Console.WriteLine("4. Add Book");
        Console.WriteLine("5. Update Book");
        Console.WriteLine("6. Delete Book");
        Console.WriteLine("7. View Customers");
        Console.WriteLine("8. Search for Customer by Name or Email");
        Console.WriteLine("9. Add new Customer");
        Console.WriteLine("10. Update Customer");
        Console.WriteLine("11. Delete Customer");
        Console.WriteLine("12. Place Order for Customer");
        Console.WriteLine("13. View Orders");
        Console.WriteLine("14. Filter orders by Customer or Date");
        Console.WriteLine("15. Logout");
    }
    
    public static void ShowCartMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Add Book to Cart");
        Console.WriteLine("2. Remove Book from Cart");
        Console.WriteLine("3. View Cart");
        Console.WriteLine("4. Checkout");
        Console.WriteLine("5. Back");
    }
    
    public static void ShowCheckoutMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Confirm Checkout");
        Console.WriteLine("2. Back");
    }

    public static void ShowUpdateBookMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Update Title");
        Console.WriteLine("2. Update Author");
        Console.WriteLine("3. Update Genre");
        Console.WriteLine("4. Update Price");
        Console.WriteLine("5. Update Quantity");
        Console.WriteLine("6. Back");
    }

    public static void ShowSearchMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Search by Title");
        Console.WriteLine("2. Search by Author");
        Console.WriteLine("3. Search by Genre");
        Console.WriteLine("4. Back");
    }

    public static void ShowSearchCustomerMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Search by Name");
        Console.WriteLine("2. Search by Email");
        Console.WriteLine("3. Back");
    }

    public static void ShowUpdateCustomerMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Update Name");
        Console.WriteLine("2. Update Email");
        Console.WriteLine("3. Back");
    }

    public static void ShowOrderFilterMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Filter by Customer");
        Console.WriteLine("2. Filter by Order Date");
        Console.WriteLine("3. Back");
    }

    public static void ShowOrderMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. View Order History");
        Console.WriteLine("2. Filter Order History");
        Console.WriteLine("3. Add new order");
        Console.WriteLine("4. Back");
    }
    
}