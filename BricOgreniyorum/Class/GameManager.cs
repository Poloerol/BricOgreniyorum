using System;
using System.Collections.Generic;
using System.Linq;

namespace BricOgreniyorum.Class
{
    public class GameManager
    {
        public List<Player> Players { get; private set; }
        public Deck CurrentDeck { get; private set; }
        public GamePhase CurrentPhase { get; private set; }
        public TrickManager TrickManager { get; private set; }
        public ScoreKeeper ScoreKeeper { get; private set; }
        public Suit? TrumpSuit { get; private set; }
        public int CurrentPlayerIndex { get; private set; }

        // Deklarasyon (Bidding) Özellikleri
        public Bid CurrentBid { get; private set; }
        public int PassCount { get; private set; }
        public List<Player> PassedPlayers { get; private set; }

        public GameManager()
        {
            Players = new List<Player>();
            CurrentPhase = GamePhase.Dealing;
            InitializePlayers();
            TrickManager = new TrickManager(this);
            ScoreKeeper = new ScoreKeeper(Players);
            PassedPlayers = new List<Player>();
        }

        private void InitializePlayers()
        {
            Players.Add(new Player("Kuzey", true));
            Players.Add(new Player("Doğu", true));
            Players.Add(new Player("Güney", false)); // Kullanıcı
            Players.Add(new Player("Batı", true));
        }

        public void StartNewGame()
        {
            CurrentPhase = GamePhase.Dealing;
            CurrentDeck = new Deck();
            CurrentDeck.Shuffle();

            foreach (var player in Players)
            {
                player.ResetScore();
                for (int i = 0; i < 13; i++)
                {
                    player.AddCardToHand(CurrentDeck.DrawCard());
                }
                player.Hand.SortHand();
            }

            CurrentPlayerIndex = 2; // Bidding always starts with South (index 2)
            CurrentBid = null;
            PassCount = 0;
            PassedPlayers.Clear();
            CurrentPhase = GamePhase.Bidding;
        }

        public void SetCurrentPlayer(int index)
        {
            CurrentPlayerIndex = index;
        }


        public void MakeBid(Player player, Bid bid)
        {
            if (CurrentBid == null || bid.CompareTo(CurrentBid) > 0)
            {
                CurrentBid = bid;
                // Eğer bu oyuncu daha önce pas geçmişse, onu listeden çıkar
                if (PassedPlayers.Contains(player))
                {
                    PassedPlayers.Remove(player);
                    PassCount--;
                }
            }
            else
            {
                throw new InvalidOperationException("Teklif mevcut tekliften daha yüksek olmalıdır.");
            }

            MoveToNextPlayer();
            CheckBiddingEnd();
        }

        public void Pass(Player player)
        {
            if (!PassedPlayers.Contains(player))
            {
                PassedPlayers.Add(player);
                PassCount++;
            }

            MoveToNextPlayer();
            CheckBiddingEnd();
        }

        private void CheckBiddingEnd()
        {
            // 3 oyuncu pas geçtiğinde deklarasyon biter
            if (PassCount >= 3)
            {
                if (CurrentBid != null)
                {
                    TrumpSuit = CurrentBid.TrumpSuit ?? Suit.Spades; // No Trump ise varsayılan olarak Maça yapalım veya özel kural ekleyelim
                }
                AdvancePhase();
            }
        }


        public Player GetCurrentPlayer()
        {
            return Players[CurrentPlayerIndex];
        }

        public void MoveToNextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
        }

        public bool IsValidMove(Player player, Card card)
        {
            if (player.Hand.Cards.Count == 0 || !player.Hand.Cards.Contains(card))
                return false;

            if (this.TrickManager.PlayedCards.Count == 0)
                return true; // Turun ilk kartı her zaman geçerlidir.

            Suit leadSuit = this.TrickManager.PlayedCards[0].Suit;

            // Elinde lider renkten kart varsa, o rengi oynamak zorundadır.
            bool hasLeadSuit = player.Hand.Cards.Any(c => c.Suit == leadSuit);
            if (hasLeadSuit && card.Suit != leadSuit)
            {
                return false;
            }

            return true;
        }

        public void SetTrumpSuit(Suit suit)
        {
            TrumpSuit = suit;
        }

        public void AdvancePhase()
        {
            switch (CurrentPhase)
            {
                case GamePhase.Dealing:
                    CurrentPhase = GamePhase.Bidding;
                    break;
                case GamePhase.Bidding:
                    CurrentPhase = GamePhase.Playing;
                    break;
                case GamePhase.Playing:
                    CurrentPhase = GamePhase.Scoring;
                    break;
                case GamePhase.Scoring:
                    CurrentPhase = GamePhase.GameOver;
                    break;
            }
        }
    }
}
