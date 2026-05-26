using System;
using System.Collections.Generic;

namespace BricOgreniyorum.Class
{
    public class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; private set; }
        public int TricksWon { get; private set; }
        public bool IsAI { get; set; }

        public Player(string name, bool isAI = true)
        {
            Name = name;
            IsAI = isAI;
            Hand = new Hand();
            TricksWon = 0;
        }

        public void AddCardToHand(Card card)
        {
            Hand.AddCard(card);
        }

        public void IncrementTricks()
        {
            TricksWon++;
        }

        public void ResetScore()
        {
            TricksWon = 0;
        }
    }
}
