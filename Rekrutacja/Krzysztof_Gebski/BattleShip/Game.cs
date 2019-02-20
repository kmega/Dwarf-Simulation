using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame
{
    public class Game

    {
        private static void GameTurn(string field, List<Player> players)
        {
            foreach (var player in CreateNonActivePlayersList(players))
            {
                if (IsFieldOnList(field, player.Ships))
                {
                    MoveFieldToOtherList(field, player.Ships, player.DestroyedShips);
                }
                else
                {
                    ChangeActivePlayer(players);
                }
            }
        }

        public static void AfterTurn(List<Player> players)
        {
            List<Player> nonActivePlayers = CreateNonActivePlayersList(players);
            List<Player> playersWithShips = nonActivePlayers.Where(p => p.Ships.Count() > 0).ToList();
            if (playersWithShips.Count() == 0)
            {
                System.Console.WriteLine("The winner is" + players.Where(p => p.IsActive == true));
            }
        }

        private static void ChangeActivePlayer(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].IsActive == true)
                {
                    players[i].IsActive = false;
                    if (i + 1 > players.Count)
                    {
                        players[0].IsActive = true;
                    }
                    else
                    {
                        players[i + 1].IsActive = true;
                    }
                }
            }
        }

        public static bool CheckIfPlayerHasAShips(Player player)
        {
            return player.Ships.Count() > 0;
        }

        private static List<Player> CreateNonActivePlayersList(List<Player> players)
        {
            return players.Where(p => p.IsActive == false).ToList();
        }

        private static void MakePlayerAsActive(List<Player> players)
        {
            players[0].IsActive = true;
        }

        public static bool IsFieldOnList(string field, List<string> list)
        {
            return list.Contains(field);
        }

        public static void MoveFieldToOtherList(string field, List<string> sourceList, List<string> destinationList)
        {
            destinationList.Add(field);
            sourceList.Remove(field);
        }

        public static void MoveFieldToOtherList(string field, List<string> destinationList)
        {
            destinationList.Add(field);
        }
    }
}