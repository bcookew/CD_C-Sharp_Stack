using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.print();
            deck.Shuffle();
            deck.print();
            // deck.Reset();
            // deck.print();
            Player Ben = new Player();
            Ben.name = "Ben";
            Ben.Discard(0);
            Ben.Draw(deck);
            Ben.Draw(deck);
            Ben.Draw(deck);
            System.Console.WriteLine("\nBen's Hand:");
            foreach (Card card in Ben.hand)
            {
                card.print();
            }
            Ben.Discard(0);
            System.Console.WriteLine("\nBen's Hand after discard:");
            foreach (Card card in Ben.hand)
            {
                card.print();
            }

        }
    }
    class Card
    {
        public string name;
        public string suit;
        public int val;

        public Card(string Name, string Suit, int Val)
        {
            suit = Suit;
            name = Name;
            val = Val;

        }
        public void print()
        {
            System.Console.WriteLine($"Card: {name} of {suit} - Value: {val}");
        }
    }
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public Deck()
        {
            NewDeck();
            System.Console.WriteLine("Constructor: ", cards.Count);
        }
        public void NewDeck()
        {
            string[] suits = {"Hearts", "Diamonds", "Spades", "Clubs"};
            string[] names = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cards.Add(new Card(names[j], suits[i], j+1));
                }
            }
            
        }
        public void print()
        {
            foreach (Card card in cards)
            {
                card.print();
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < 52; i++)
            {
                Card temp = cards[i];
                int num = rand.Next(0, cards.Count);
                cards[i] = cards[num];
                cards[num] = temp;
            }
        }

        public void Reset()
        {
            System.Console.WriteLine("\n\nReset: ", cards.Count);
            NewDeck();
        }

        public Card Deal()
        {
            Card temp = cards[0];
            cards.RemoveAt(0);
            return temp;
        }
    }
    class Player
    {
        public string name{get; set;}
        public List<Card> hand = new List<Card>();

        public Card Draw(Deck deck)
        {
            Card temp = deck.Deal();
            hand.Add(temp);
            return temp;
        }
        public Card Discard(int index)
        {
            if (index >= 0 && index < hand.Count)
            {
                Card temp = hand[index];
                hand.RemoveAt(index);
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
}
