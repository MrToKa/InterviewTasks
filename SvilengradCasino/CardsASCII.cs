using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvilengradCasino
{
    internal class CardsASCII
    {
        private static char[,] cardGraphic = new char[,]
        {
            {'+', '-', '-', '-', '-', '-', '+'},
            {'|', ' ', ' ', ' ', ' ', ' ', '|'},
            {'|', ' ', ' ', ' ', ' ', ' ', '|'},
            {'|', ' ', ' ', ' ', ' ', ' ', '|'},
            {'|', ' ', ' ', ' ', ' ', ' ', '|'},
            {'|', ' ', ' ', ' ', ' ', ' ', '|'},
            {'+', '-', '-', '-', '-', '-', '+'}
        };

        private static int[] suiteTLPositions = new int[] { 1, 1 };
        private static int[] suiteBRPositions = new int[] { 5, 5 };
        private static int[] rankPositions = new int[] { 3, 3 };

        public static void PrintCard(string card)
        {
            string[] cardParts = card.Split(' ');
            string rank = cardParts[0];
            string suite = cardParts[2];

            char rankPosition = ' ';
            char suiteChar = ' ';


            switch (rank)
            {
                case "Ace":
                    rankPosition = '1';
                    break;
                case "Two":
                    rankPosition = '2';
                    break;
                case "Three":
                    rankPosition = '3';
                    break;
                case "Four":
                    rankPosition = '4';
                    break;
                case "Five":
                    rankPosition = '5';
                    break;
                case "Six":
                    rankPosition = '6';
                    break;
                case "Seven":
                    rankPosition = '7';
                    break;
                case "Eight":
                    rankPosition = '8';
                    break;
                case "Nine":
                    rankPosition = '9';
                    break;
                case "Ten":
                    rankPosition = 'T';
                    break;
                case "Jack":
                    rankPosition = 'J';
                    break;
                case "Queen":
                    rankPosition = 'Q';
                    break;
                case "King":
                    rankPosition = 'K';
                    break;
            }

            switch (suite)
            {
                case "Spades":
                    suiteChar = '♠';
                    break;
                case "Hearts":
                    suiteChar = '♥';
                    break;
                case "Diamonds":
                    suiteChar = '♦';
                    break;
                case "Clubs":
                    suiteChar = '♣';
                    break;
            }

            if (rankPosition == '1')
            {
                cardGraphic[rankPositions[0], rankPositions[1]] = 'A';
                cardGraphic[rankPositions[0], rankPositions[1] + 1] = ' ';
            }
            if (rankPosition == 'T')
            {
                cardGraphic[rankPositions[0], rankPositions[1]] = '1';
                cardGraphic[rankPositions[0], rankPositions[1] + 1] = '0';
            }
            if (rankPosition == 'J')
            {
                cardGraphic[rankPositions[0], rankPositions[1]] = 'J';
                cardGraphic[rankPositions[0], rankPositions[1] + 1] = ' ';
            }
            if (rankPosition == 'Q')
            {
                cardGraphic[rankPositions[0], rankPositions[1]] = 'Q';
                cardGraphic[rankPositions[0], rankPositions[1] + 1] = ' ';
            }
            if (rankPosition == 'K')
            {
                cardGraphic[rankPositions[0], rankPositions[1]] = 'K';
                cardGraphic[rankPositions[0], rankPositions[1] + 1] = ' ';
            }
            if (rankPosition != '1' && rankPosition != 'T' && rankPosition != 'J' && rankPosition != 'Q' && rankPosition != 'K')            
            {
                cardGraphic[rankPositions[0], rankPositions[1]] = rankPosition;
                cardGraphic[rankPositions[0], rankPositions[1] + 1] = ' ';
            }

            cardGraphic[suiteTLPositions[0], suiteTLPositions[1]] = suiteChar;
            cardGraphic[suiteBRPositions[0], suiteBRPositions[1]] = suiteChar;
        }

        public static void PrintCardGraphic()
        {
            for (int row = 0; row < cardGraphic.GetLength(0); row++)
            {
                for (int col = 0; col < cardGraphic.GetLength(1); col++)
                {
                    Console.Write(cardGraphic[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintHandGraphic(List<string> hand)
        {
            int cardWidth = cardGraphic.GetLength(1);
            int cardHeight = cardGraphic.GetLength(0);

            int handWidth = cardWidth * hand.Count;
            int handHeight = cardHeight;

            char[,] handGraphic = new char[handHeight, handWidth];

            for (int row = 0; row < handGraphic.GetLength(0); row++)
            {
                for (int col = 0; col < handGraphic.GetLength(1); col++)
                {
                    handGraphic[row, col] = ' ';
                }
            }

            for (int i = 0; i < hand.Count; i++)
            {
                string[] cardParts = hand[i].Split(' ');
                string rank = cardParts[0];
                string suite = cardParts[2];

                PrintCard(hand[i]);

                for (int row = 0; row < cardGraphic.GetLength(0); row++)
                {
                    for (int col = 0; col < cardGraphic.GetLength(1); col++)
                    {
                        handGraphic[row, col + (i * cardWidth)] = cardGraphic[row, col];
                    }
                }
            }

            for (int row = 0; row < handGraphic.GetLength(0); row++)
            {
                for (int col = 0; col < handGraphic.GetLength(1); col++)
                {
                    Console.Write(handGraphic[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
