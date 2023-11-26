using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvilengradCasino
{
    internal class Cards
    {
        private string suit;
        private string rank;

        public string Suit { get; }
        public string Rank { get; }

        public Cards(string suit, string rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }

        public static List<string> GenerateDeck()
        {
            List<string> deck = new List<string>();

            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                                          "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            return deck;
        }

        public static List<string> ShuffleDeck(List<string> deck)
        {
            Random random = new Random();

            for (int i = 0; i < deck.Count; i++)
            {
                int randomIndex = random.Next(0, deck.Count);

                string temp = deck[i];
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }

            return deck;
        }

        public static List<string> DealCards(List<string> deck, int numberOfCards)
        {
            List<string> hand = new List<string>();

            for (int i = 0; i < numberOfCards; i++)
            {
                hand.Add(deck[i]);
            }

            return hand;
        }

        public static int GetCardValue(string card)
        {
            int value = 0;

            if (card.Contains("Ace"))
            {
                value = 11;
            }
            else if (card.Contains("Two"))
            {
                value = 2;
            }
            else if (card.Contains("Three"))
            {
                value = 3;
            }
            else if (card.Contains("Four"))
            {
                value = 4;
            }
            else if (card.Contains("Five"))
            {
                value = 5;
            }
            else if (card.Contains("Six"))
            {
                value = 6;
            }
            else if (card.Contains("Seven"))
            {
                value = 7;
            }
            else if (card.Contains("Eight"))
            {
                value = 8;
            }
            else if (card.Contains("Nine"))
            {
                value = 9;
            }
            else if (card.Contains("Ten") || card.Contains("Jack") || card.Contains("Queen") || card.Contains("King"))

            {
                value = 10;
            }

            return value;
        }

        public static int GetHandValue(List<string> hand)
        {
            int value = 0;
            bool firstAce = AceValueCheck(hand[0]);
            bool secondAce = AceValueCheck(hand[1]);
            bool thirdAce = false;
            bool fourthAce = false;

            if (hand.Count == 3)
            {
                thirdAce = AceValueCheck(hand[2]);
            }
            if (hand.Count == 4)
            {
                thirdAce = AceValueCheck(hand[3]);
            }

            foreach (string card in hand)
            {             
                value += GetCardValue(card);

                if (value > 21 && AceValueCheck(card))
                {
                    value -= 10;
                }
                else if (value > 21 && firstAce)
                {
                    value -= 10;
                    firstAce = false;
                }
                else if (value > 21 && secondAce)
                {
                    value -= 10;
                    secondAce = false;
                }
                else if (value > 21 && thirdAce)
                {
                    value -= 10;
                    thirdAce = false;
                }
                else if (value > 21 && fourthAce)
                {
                    value -= 10;
                    fourthAce = false;
                }
                
            }

            return value;
        }

        public static void PrintHand(List<string> hand)
        {
            foreach (string card in hand)
            {
                Console.WriteLine(card);
            }
        }

        private static bool AceValueCheck(string card)
        {
            if (card.Contains("Ace"))
            {
                return true;
            }

            return false;

        }

        public static void PrintTable(List<string> hand, List<string> dealerHand)
        {
            Console.WriteLine("Your hand:");
            CardsASCII.PrintHandGraphic(hand);
            Console.WriteLine($"Hand value: {GetHandValue(hand)}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Dealer's hand:");
            CardsASCII.PrintHandGraphic(dealerHand);
            Console.WriteLine($"Hand value: {GetHandValue(dealerHand)}");
            Console.WriteLine("----------------------------");
        }
    }
}
