using static SvilengradCasino.CasinoDatabase;

namespace SvilengradCasino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            //Menu.WelcomeMenu.Welcome();

            //bool isLogged = false;
            //while (!isLogged)
            //{                
            //    int choice = Validations.CheckIntInput("Enter your choice: ");

            //    switch (choice)
            //    {
            //        case 1:

            //            string username = Validations.CheckStringInput("Enter your username: ");
            //            string password = Validations.CheckStringInput("Enter your password: ");

            //            if (PlayerManipulation.IsRegistered(username, password))
            //            {
            //                Console.WriteLine("You are logged in!");
            //                isLogged = true;
            //            }
            //            else
            //            {
            //                Console.WriteLine("Wrong username or password!");
            //            }

            //            break;
            //        case 2:
            //            string newUsername = Validations.CheckStringInput("Enter your username: ");
            //            if (PlayerManipulation.IsUsernameExist(newUsername))
            //            {
            //                Console.WriteLine("Username already exists!");
            //                break;
            //            }
            //            string newPassword = Validations.CheckStringInput("Enter your password: ");
            //            decimal newBalance = 0;

            //            Player player = new Player(newUsername, newPassword, newBalance);

            //            PlayerManipulation.Register(player);
            //            Console.WriteLine("You are registered!");

            //            break;
            //        case 3:
            //            Console.WriteLine("Goodbye!");
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            Console.WriteLine("Wrong choice!");
            //            break;
            //    }
            //}

            //while (isLogged)
            //{
            //    Menu.MainMenu.ShowMainMenu();
            //    int choice = Validations.CheckIntInput("Enter your choice: ");

            //    switch (choice)
            //    {
            //        case 1:
            //            Console.WriteLine("Play");
            //            break;
            //        case 2:
            //            Console.WriteLine("Deposit");
            //            break;
            //        case 3:
            //            Console.WriteLine("Withdraw");
            //            break;
            //        case 4:
            //            Console.WriteLine("Show balance");
            //            break;
            //        case 5:
            //            Console.WriteLine("Delete account");
            //            break;
            //        case 6:
            //            Console.WriteLine("Logout");
            //            break;
            //        default:
            //            Console.WriteLine("Wrong choice!");
            //            break;
            //    }

            while (true)
            {
                PokerGame.Play(new Player("test", "test", 1000));
            }




        }
    }
}
