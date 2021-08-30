using System;
using System.Collections.Generic;
using System.Text;

namespace Deck_Of_Cards
{
    class Cards
    {
        int PLAYER_CARDS = 9;

        //Arrays
        public string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        public string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        string[] players = { "1", "2", "3", "4" };


        public void CardsCreator()
        {
            int index = 0;
            string[,] Cards = new string[suits.Length, rank.Length];
            string[] newCards = new string[52];
            string[,] playersCards = new string[players.Length, PLAYER_CARDS];

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < rank.Length; j++)
                {
                    Cards[i, j] = String.Concat(suits[i] + "-" + rank[j]);
                    newCards[index] = Cards[i, j];
                    index++;
                }
            }

            Random random = new Random();
            int randomCard;

            for (int i = 0; i < newCards.Length; i++)
            {
                randomCard = random.Next(0, newCards.Length);
                string temp = newCards[i]; 
                newCards[i] = newCards[randomCard];
                newCards[randomCard] = temp;
            }
            int counter = 0;
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < PLAYER_CARDS; j++)
                {
                    playersCards[i, j] = newCards[counter];
                    counter++;
                }
            } 
            Display(playersCards);
        }
        public void Display(string[,] playersCards)
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("########################");
                Console.WriteLine("Player {0} cards:", i + 1);
                Console.WriteLine("########################");
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine(playersCards[i, j]);
                }
            }
        }
    }
}
