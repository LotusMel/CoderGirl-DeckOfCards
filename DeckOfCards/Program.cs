using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public static class Program
    {
        public static void Main()
        {
            // Create a deck cards.
            Deck deck = new Deck();

            // Draw a card.
            var card = deck.PickRandomCard();

            // Show the value.
            Console.WriteLine(card.GetFullName());

            List<Card> kingCards = deck.GetCardsOfFaceValue(FaceValue.King);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}