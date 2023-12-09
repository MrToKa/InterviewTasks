using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvilengradCasino
{
    internal class PokerGame
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
                    List<string> hand = Cards.DealCards(deck, 5);

                    Cards.PrintTable(hand);

                    Console.WriteLine("Which cards you want to hold?");
                    string[] cardsToHold = Console.ReadLine().Split(' ');

                    deck = Cards.ShuffleDeck(deck);

                    for (int i = 0; i < hand.Count; i++)
                    {
                        if (cardsToHold.Contains((i + 1).ToString()))
                        {
                            continue;
                        }

                        deck = Cards.ShuffleDeck(deck);
                        hand[i] = Cards.DealCards(deck, 1)[0];
                        
                    }                    

                    Cards.PrintTable(hand);

                    InGameLogic(hand);

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

        private static void InGameLogic(List<string> hand)
        {
            List<(string, int)> cardValues = new List<(string, int)>();

            foreach (string card in hand)
            {
                var cardValue = Cards.GetCardValue(card);
                var cardSuit = Cards.GetCardSuit(card);

                cardValues.Add((cardSuit, cardValue));
            }


            GameDeciderLogic(cardValues);

        }

        private static void GameDeciderLogic(List<(string, int)> cardValues)
        {
            int pairCount = 0;
            int threeOfAKindCount = 0;
            int fourOfAKindCount = 0;
            int flushCount = 0;
            int straightCount = 0;
            int straightFlushCount = 0;
            int royalFlushCount = 0;

            foreach (var card in cardValues)
            {
                if (cardValues.Where(x => x.Item2 == card.Item2).Count() == 2)
                {
                    pairCount++;
                }
                else if (cardValues.Where(x => x.Item2 == card.Item2).Count() == 3)
                {
                    threeOfAKindCount++;
                }
                else if (cardValues.Where(x => x.Item2 == card.Item2).Count() == 4)
                {
                    fourOfAKindCount++;
                }
                else if (cardValues.Where(x => x.Item1 == card.Item1).Count() == 5)
                {
                    flushCount++;
                }
                else if (cardValues.Where(x => x.Item2 == card.Item2 + 1).Count() == 5)
                {
                    straightCount++;
                }
                else if (cardValues.Where(x => x.Item2 == card.Item2 + 1).Count() == 5 && cardValues.Where(x => x.Item1 == card.Item1).Count() == 5)
                {
                    straightFlushCount++;
                }
                else if (cardValues.Where(x => x.Item2 == 10).Count() == 4 && cardValues.Where(x => x.Item2 == 11).Count() == 1)
                {
                    royalFlushCount++;
                }
            }

            if (royalFlushCount >= 1)
            {
                Console.WriteLine("Royal Flush!");
            }
            else if (straightFlushCount >= 1)
            {
                Console.WriteLine("Straight Flush!");
            }
            else if (fourOfAKindCount >= 1)
            {
                Console.WriteLine("Four of a kind!");
            }
            else if (threeOfAKindCount >= 1 && pairCount >= 1)
            {
                Console.WriteLine("Full House!");
            }
            else if (flushCount >= 1)
            {
                Console.WriteLine("Flush!");
            }
            else if (straightCount >= 1)
            {
                Console.WriteLine("Straight!");
            }
            else if (threeOfAKindCount >= 1)
            {
                Console.WriteLine("Three of a kind!");
            }
            else if (pairCount >= 2)
            {
                Console.WriteLine("Two pairs!");
            }
            else
            {
                Console.WriteLine("Nothing");
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

    }
}
