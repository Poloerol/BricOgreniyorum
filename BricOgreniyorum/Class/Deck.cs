using System;
using System.Collections.Generic;
using System.Linq;

namespace BricOgreniyorum
{
    public class Deck
    {
        private readonly List<Card> _cards;
        private readonly Random _random = new Random();

        public Deck()
        {
            _cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        public Card DrawCard()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("The deck is empty.");

            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public int Count => _cards.Count;
    }
}
