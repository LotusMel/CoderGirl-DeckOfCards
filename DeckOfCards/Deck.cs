using System;
using System.Collections.Generic;
using System.Linq;


namespace DeckOfCards
{
    public enum Suit
    {
        Hearts, 
        Spades,
        Clubs,
        Diamonds
    }

    public enum FaceValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Deck
    {
        private Random random;

        public List<Card> Cards { get; set; }

        public Deck()
        {
            AddCardsToDeck();
            Shuffle();
        }

        public Card PickRandomCard()
        {
            int randomIndex = random.Next(0, Cards.Count);
            Card card = Cards[randomIndex];
            return card;
        }

        public Card DrawCard()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public List <Card> DrawCards(int number)
        {
            List<Card> drawnCards = Cards.Take(number).ToList();
            Cards.RemoveAll(card => drawnCards.Contains(card));
            return drawnCards;
        }

        public void CutDeck(int number)
        {
            List<Card> bottomCut = Cards.TakeLast(number).ToList();
            Cards.RemoveRange(0, number);
            Cards.AddRange(bottomCut);
        }

        /// <summary>
        /// Shuffle using the Fisher Yates algorithm
        /// <see cref="https://www.dotnetperls.com/fisher-yates-shuffle"/>
        /// </summary>

        public void Shuffle()
        {
            random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int randomIndex = i + random.Next(Cards.Count - i);
                Card cardToSwap = Cards[randomIndex];
                Cards[randomIndex] = Cards[i];
                Cards[i] = cardToSwap;
            }
        }

        public List<Card> GetCardsOfSuit(Suit suit)
        {
            var cardsOfSuit = Cards.Where(card => card.Suit == suit).ToList();
            return cardsOfSuit;
        }

        public List<Card> GetCardsOfFaceValue(FaceValue faceValue)
        {
            var cardsOfFaceValue = Cards.Where(card => card.FaceValue == faceValue).ToList();
            return cardsOfFaceValue;
        }

        private void AddCardsToDeck()
        {
            Cards = new List<Card>();

            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue faceValue in Enum.GetValues(typeof(Suit)))
                {
                    Card card = new Card(faceValue, suit);
                    Cards.Add(card);
                }
            }
        }

         
          


        
    }
}