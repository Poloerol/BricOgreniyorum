using System;

namespace BricOgreniyorum.Class
{
    public class Bid : IComparable<Bid>
    {
        public int TrickCount { get; }
        public Suit? TrumpSuit { get; } // null means No Trump

        public Bid(int trickCount, Suit? trumpSuit)
        {
            TrickCount = trickCount;
            TrumpSuit = trumpSuit;
        }

        public override string ToString()
        {
            if (TrumpSuit == null)
                return $"{TrickCount} No Trump";

            return $"{TrickCount} {TrumpSuit}";
        }

        public int CompareTo(Bid other)
        {
            if (other == null) return 1;

            // Bridge bidding priority:
            // 1. Higher TrickCount always wins.
            // 2. If TrickCount is the same, the higher suit priority wins.
            if (this.TrickCount > other.TrickCount) return 1;
            if (this.TrickCount < other.TrickCount) return -1;

            int thisPriority = GetSuitPriority(this.TrumpSuit);
            int otherPriority = GetSuitPriority(other.TrumpSuit);

            if (thisPriority > otherPriority) return 1;
            if (thisPriority < otherPriority) return -1;

            return 0;
        }

        private int GetSuitPriority(Suit? suit)
        {
            if (suit == null) return 5; // No Trump is highest
            switch (suit)
            {
                case Suit.Spades: return 4;
                case Suit.Hearts: return 3;
                case Suit.Diamonds: return 2;
                case Suit.Clubs: return 1;
                default: return 0;
            }
        }
    }
}
