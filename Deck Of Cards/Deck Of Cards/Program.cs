using System;

namespace Deck_Of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Deck Of Cards");

            Cards cards = new Cards();
            cards.CardsCreator();
        }
    }
}
