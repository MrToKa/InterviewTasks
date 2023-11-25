namespace OnlineBookstoreManagement;

public class User
{
    private string _username;
    private string _password;

    public string Username
    {
        get => _username;
        set => _username = value;
    }

    public string Password
    {
        get => _password;
        set => _password = value;
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public override string ToString()
    {
        return $"{Username},{Password}";
    }
}