using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLeaderboard
{
    public class LeaderboardService
    {
        public static List<(string Name, int Score)> GetTopKPlayers(
            List<(string Name, int Score)> players,
            int topCount)
        {
            if (players == null)
                throw new ArgumentNullException(nameof(players));

            if (topCount <= 0)
                return new List<(string Name, int Score)>();

            var sortedPlayers = players
                .OrderByDescending(player => player.Score)  // Primary sort
                .ThenBy(player => player.Name)              // Tie-breaker
                .Take(topCount)
                .ToList();

            return sortedPlayers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<(string Name, int Score)>
            {
                ("Raj", 80),
                ("Anu", 95),
                ("Vikram", 95),
                ("Meena", 70)
            };

            int k = 3;

            var topPlayers = LeaderboardService.GetTopKPlayers(players, k);

            Console.WriteLine("Top Players:");

            foreach (var player in topPlayers)
            {
                Console.WriteLine($"{player.Name} - {player.Score}");
            }
        }
    }
}
