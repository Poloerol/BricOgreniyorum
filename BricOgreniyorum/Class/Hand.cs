using System;
using System.Collections.Generic;
using System.Linq;

namespace BricOgreniyorum
{
    public class Hand
    {
        public List<Card> Cards { get; } = new List<Card>();

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void SortHand()
        {
            // Sort by Suit then by Rank (Descending)
            // In Bridge, usually Spades > Hearts > Diamonds > Clubs
            var suitOrder = new Dictionary<Suit, int>
            {
                { Suit.Spades, 0 },
                { Suit.Hearts, 1 },
                { Suit.Diamonds, 2 },
                { Suit.Clubs, 3 }
            };

            var sorted = Cards
                .OrderBy(c => suitOrder[c.Suit])
                .ThenByDescending(c => c.Rank)
                .ToList();

            Cards.Clear();
            Cards.AddRange(sorted);
        }

        public Card PlayCard(Card card)
        {
            if (!Cards.Contains(card))
                throw new ArgumentException("Card is not in hand.");

            Cards.Remove(card);
            return card;
        }

        public int Count => Cards.Count;
    }
}
