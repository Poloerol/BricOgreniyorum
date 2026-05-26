using System;
using System.Collections.Generic;
using System.Linq;

namespace BricOgreniyorum.Class
{
    public class TrickManager
    {
        private readonly GameManager _gameManager;
        public List<Card> PlayedCards { get; private set; }
        public List<Player> CardOrder { get; private set; }

        public TrickManager(GameManager gameManager)
        {
            _gameManager = gameManager;
            PlayedCards = new List<Card>();
            CardOrder = new List<Player>();
        }

        public void PlayCard(Player player, Card card)
        {
            PlayedCards.Add(card);
            CardOrder.Add(player);
        }

        public Player DetermineWinner()
        {
            if (PlayedCards.Count == 0) return null;

            Suit leadSuit = PlayedCards[0].Suit;
            int winnerIndex = 0;
            Card winningCard = PlayedCards[0];

            for (int i = 1; i < PlayedCards.Count; i++)
            {
                Card currentCard = PlayedCards[i];
                bool isBetter = false;

                // Koz kartı kontrolü
                if (currentCard.Suit == _gameManager.TrumpSuit)
                {
                    if (winningCard.Suit != _gameManager.TrumpSuit || currentCard.Rank > winningCard.Rank)
                    {
                        isBetter = true;
                    }
                }
                // Koz değilse ama lider renkteyse
                else if (currentCard.Suit == leadSuit && winningCard.Suit != _gameManager.TrumpSuit)
                {
                    if (winningCard.Suit != leadSuit || currentCard.Rank > winningCard.Rank)
                    {
                        isBetter = true;
                    }
                }

                if (isBetter)
                {
                    winnerIndex = i;
                    winningCard = currentCard;
                }
            }

            return CardOrder[winnerIndex];
        }

        public void ClearTrick()
        {
            PlayedCards.Clear();
            CardOrder.Clear();
        }
    }
}
