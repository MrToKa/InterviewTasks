
namespace SvilengradCasino
{
    internal class BlackJackGame
    {
        public static void Play(Player player)
        {
            decimal currentBet = 0;
            Menu.GamesMenu.ShowCardsGameMenu();

            bool isPlaying = false;

            int choice = Validations.CheckIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    if (player.Balance == 0 || currentBet > player.Balance)
                    {
                        Console.WriteLine("You don't have enough money!");
                        isPlaying = false;
                        break;
                    }

                    if (currentBet == 0 || isPlaying == false)
                    {
                        Console.WriteLine("Before you start playing you need to bet!");
                        currentBet = Bet(player);
                    }

                    isPlaying = true;

                    List<string> deck = Cards.GenerateDeck();
                    deck = Cards.ShuffleDeck(deck);
                    List<string> hand = Cards.DealCards(deck, 2);
                    deck = Cards.ShuffleDeck(deck);
                    List<string> dealerHand = Cards.DealCards(deck, 2);

                    Cards.PrintTable(hand, dealerHand);

                    if (!GameDeciderInstantLogic(hand, dealerHand, player, currentBet))
                    {
                        break;
                    }

                    InGameLogic(deck, hand, dealerHand, player, currentBet);
                    break;


                case 2:
                    currentBet = Bet(player);
                    isPlaying = true;

                    break;
                default:
                    Console.WriteLine("Wrong choice!");
                    break;


            }
        }

        public static bool GameDeciderInstantLogic(List<string> hand, List<string> dealerHand, Player player, decimal currentBet)
        {
            int handValue = Cards.GetHandValue(hand);
            int dealerHandValue = Cards.GetHandValue(dealerHand);

            if (handValue > 21)
            {
                Console.WriteLine("You lose!");
                UpdateBalance(player, currentBet, "lose");
                return false;
            }

            if (dealerHandValue > 21)
            {
                Console.WriteLine("You win!");
                UpdateBalance(player, currentBet, "win");
                return false;
            }
            if (handValue == 21 && dealerHandValue == 21)
            {
                Console.WriteLine("Draw!");
                return false;
            }
            if (handValue == 21)
            {
                Console.WriteLine("You win!");
                UpdateBalance(player, currentBet, "win");
                return false;
            }

            if (dealerHandValue == 21)
            {
                Console.WriteLine("You lose!");
                UpdateBalance(player, currentBet, "lose");
                return false;
            }

            if (hand.Count > 5)
            {
                Console.WriteLine("You lose!");
                UpdateBalance(player, currentBet, "lose");
                return false;
            }

            if (dealerHand.Count > 5)
            {
                Console.WriteLine("You win!");
                UpdateBalance(player, currentBet, "win");
                return false;
            }

            return true;
        }

        public static bool GameDeciderLogic(List<string> hand, List<string> dealerHand, Player player, decimal currentBet)
        {
            int handValue = Cards.GetHandValue(hand);
            int dealerHandValue = Cards.GetHandValue(dealerHand);

            if (handValue > dealerHandValue)
            {
                Console.WriteLine("You win!");
                UpdateBalance(player, currentBet, "win");
                return false;
            }

            if (handValue < dealerHandValue)
            {
                Console.WriteLine("You lose!");
                UpdateBalance(player, currentBet, "lose");
                return false;
            }

            if (handValue == dealerHandValue)
            {
                Console.WriteLine("Draw!");
                return false;
            }

            return true;
        }

        public static void InGameLogic(List<string> deck, List<string> hand, List<string> dealerHand, Player player, decimal currentBet)
        {
            bool isPlaying = true;
            while (isPlaying)
            {
                Menu.BlackJackGameMenu.ShowHitOrHoldMenu();
                int choice = Validations.CheckIntInput("Do you want to hit or hold?");

                switch (choice)
                {
                    case 1:
                        Hit(deck, hand, dealerHand);
                        Cards.PrintTable(hand, dealerHand);
                        isPlaying = GameDeciderInstantLogic(hand, dealerHand, player, currentBet);
                        break;
                    case 2:
                        Hold(deck, dealerHand);
                        Cards.PrintTable(hand, dealerHand);
                        if (!GameDeciderInstantLogic(hand, dealerHand, player, currentBet))
                        {
                            return;
                        }
                        isPlaying = GameDeciderLogic(hand, dealerHand, player, currentBet);
                        break;

                    case 3:                        
                        isPlaying = GameDeciderLogic(hand, dealerHand, player, currentBet);
                        break;

                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
        }

        public static void UpdateBalance(Player player, decimal currentBet, string result)
        {
            if (result == "win")
            {
                player.Balance += currentBet;
            }
            else if (result == "lose")
            {
                player.Balance -= currentBet;
            }
        }

        public static decimal Bet(Player player)
        {
            decimal newBet = Validations.CheckDecimalInput("Enter your bet: ");

            if (newBet > player.Balance)
            {
                Console.WriteLine("You don't have enough money!");
                return 0;
            }

            return newBet;
        }

        public static void Hit(List<string> deck, List<string> hand, List<string> dealerHand)
        {
            deck = Cards.ShuffleDeck(deck);
            List<string> playerCard = Cards.DealCards(deck, 1);
            hand.AddRange(playerCard);

            if (Cards.GetHandValue(hand) > 21 || hand.Count == 5)
            {
                return;
            }

            if (Cards.GetHandValue(dealerHand) < 17 && dealerHand.Count < 5)
            {
                deck = Cards.ShuffleDeck(deck);
                List<string> dealerCard = Cards.DealCards(deck, 1);
                dealerHand.AddRange(dealerCard);
            }
        }

        public static void Hold(List<string> deck, List<string> dealerHand)
        {
            while (Cards.GetHandValue(dealerHand) < 17 && dealerHand.Count < 5)
            {
                deck = Cards.ShuffleDeck(deck);
                List<string> card = Cards.DealCards(deck, 1);
                dealerHand.AddRange(card);
            }
        }


    }
}
