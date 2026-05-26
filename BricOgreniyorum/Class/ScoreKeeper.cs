using System.Collections.Generic;

namespace BricOgreniyorum.Class
{
    public class ScoreKeeper
    {
        public Dictionary<Player, int> TotalTricks { get; private set; }

        public ScoreKeeper(List<Player> players)
        {
            TotalTricks = new Dictionary<Player, int>();
            foreach (var player in players)
            {
                TotalTricks[player] = 0;
            }
        }

        public void AddTrick(Player winner)
        {
            if (winner != null)
            {
                TotalTricks[winner]++;
                winner.IncrementTricks();
            }
        }

        public void ResetScores()
        {
            foreach (var player in TotalTricks.Keys)
            {
                TotalTricks[player] = 0;
            }
        }
    }
}
