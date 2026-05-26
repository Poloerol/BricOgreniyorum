using System;

namespace BricOgreniyorum
{
    public class Card
    {
        public Suit Suit { get; }
        public CardRank Rank { get; }

        public Card(Suit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Card other)
            {
                return Suit == other.Suit && Rank == other.Rank;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Suit.GetHashCode();
                hash = hash * 23 + Rank.GetHashCode();
                return hash;
            }
        }
    }
}
