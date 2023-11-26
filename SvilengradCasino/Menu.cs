using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvilengradCasino
{
    internal class Menu
    {
        internal class WelcomeMenu
        {
            public static void Welcome()
            {
                Console.WriteLine("Welcome to Svilengrad Casino!");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("----------------------------");
            }
        }

        internal class MainMenu
        {
            public static void ShowMainMenu()
            {
                Console.WriteLine("1. Games");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Show balance");
                Console.WriteLine("5. Delete account");
                Console.WriteLine("6. Logout");
                Console.WriteLine("----------------------------");
            }

            public static void ShowDeleteAccountConfirmationMenu()
            {
                Console.WriteLine("Are you sure you want to delete your account?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.WriteLine("----------------------------");
            }

            public static void ShowLogoutConfirmationMenu()
            {
                Console.WriteLine("Are you sure you want to logout?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.WriteLine("----------------------------");
            }

        }

        internal class GamesMenu
        {
            public static void ShowGamesMenu()
            {
                Console.WriteLine("1. Roulette");
                Console.WriteLine("2. Blackjack");
                Console.WriteLine("3. Poker");
                Console.WriteLine("4. Back");
                Console.WriteLine("----------------------------");
            }

            public static void ShowRouletteMenu()
            {
                Console.WriteLine("1. Play new Spin");
                Console.WriteLine("2. Change bet");
                Console.WriteLine("3. Back");
                Console.WriteLine("----------------------------");
            }

            public static void ShowCardsGameMenu()
            {
                Console.WriteLine("1. Play new Deal");
                Console.WriteLine("2. Change bet");
                Console.WriteLine("3. Back");
                Console.WriteLine("----------------------------");
            }  
        }

        internal class BlackJackGameMenu
        {
            public static void ShowHitOrHoldMenu()
            {
                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Hold");
                Console.WriteLine("3. Fold");
                Console.WriteLine("----------------------------");
            }

            public static void ShowDoubleConfirmationMenu()
            {
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.WriteLine("----------------------------");
            }


        }
    }
}
