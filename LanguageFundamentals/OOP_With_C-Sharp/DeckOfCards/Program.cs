using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Card aceofspades = new Card();
            aceofspades.suit = "Spades";
            aceofspades.name = "Ace";
            aceofspades.val = 13;
            aceofspades.print();
        }
    }
    class Card
    {
        public string name;
        public string suit;
        public int val;
        public void print()
        {
            System.Console.WriteLine($"Card: {this.name} of {this.suit} - Value: {this.val}");
        }
    }
}
