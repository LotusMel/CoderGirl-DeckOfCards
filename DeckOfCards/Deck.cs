using System;

namespace DeckOfCards
{
    public class Deck
    {
        private Random random;
        private string[] suits = { "Hearts", "Spades", "Clubs", "Diamonds" };
        private string[] faceValues = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };


        public Deck()
        {
            random = new Random();

            Cards = new Card[52];
            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i] = new Card();
            }

            int cardCount = 0;
            for (int i = 0; i < 4; i++)
            {
                //assign Suit
                for (int j = 0; j < 13; j++)
                {
                    Card card = Cards[cardCount];
                    card.Suit = suits[i];
                    card.FaceValue = faceValues[j];
                    cardCount++;

                }

            }
            // TODO: Load the card deck with a standard deck of 52 cards.  Use loops, do not hard code each one.
        }

        public Card[] Cards { get; set; }

        public Card Draw()
        {
            // TODO: Return a random card from the deck.
            int randomIndex = random.Next(0, 52);
            Card card = Cards[randomIndex];
            return card;
        }
    }
}