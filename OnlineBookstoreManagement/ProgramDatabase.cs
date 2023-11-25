namespace OnlineBookstoreManagement;

public class ProgramDatabase
{
    //This method creates Users.txt file if it doesn't exist
    public static void CreateUsersFile()
    {
        if (!File.Exists("Users.txt"))
        {
            File.Create("Users.txt");
        }
    }

    //This method creates Books.txt file if it doesn't exist
    public static void CreateBooksFile()
    {
        if (!File.Exists("Books.txt"))
        {
            File.Create("Books.txt");
        }
    }

    //This method creates Customers.txt file if it doesn't exist
    public static void CreateCustomersFile()
    {
        if (!File.Exists("Customers.txt"))
        {
            File.Create("Customers.txt");
        }
    }

    //This method creates Orders.txt file if it doesn't exist
    public static void CreateOrdersFile()
    {
        if (!File.Exists("Orders.txt"))
        {
            File.Create("Orders.txt");
        }
    }

    //This method creates OrderDetails.txt file if it doesn't exist
    public static void CreateOrderDetailsFile()
    {
        if (!File.Exists("OrderDetails.txt"))
        {
            File.Create("OrderDetails.txt");
        }
    }

    //this method checks if the user exists in the Users.txt file
    public static bool IsUserExist(string email, string password)
    {
        string[] users = File.ReadAllLines("Users.txt");
        foreach (var user in users)
        {
            string[] userDetail = user.Split(",");
            if (userDetail[0] == email && userDetail[1] == password)
            {
                return true;
            }
        }

        return false;
    }
}