using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public void StartGame(List<Player> players)
        {
            SetActivePlayer(players);
            while (WhetherInactivePlayersHasShips(Players))
            {
                string field = "A0"; //field input by active player

                var inactivePlayers = CreateInactivePlayersList(Players);
                Turn(inactivePlayers, field);
            }
            var activePlayer = players.Where(p => p.IsActive == true).First();
            Console.WriteLine($"The winner is: " + activePlayer.IsActive);
        }

        private List<Player> CreateInactivePlayersList(List<Player> players)
        {
            return players.Where(p => p.IsActive == false).ToList();
        }

        private void Turn(List<Player> players, string field)
        {
            if (ShipIsHit(field, players))
            {
                foreach (var player in Players)
                {
                    foreach (var ship in player.Ships)
                    {
                        MoveFieldFromOneListToAnother(field, ship.OccupiedPositions, ship.DamagedPositions);
                        if (ship.OccupiedPositions.Count() == 0)
                        {
                            Console.WriteLine($"The ship {ship.Type} has been destroyed");
                        }
                    }
                }
                
            }
            else
            {
                ChangeActivePlayer(players);
            }
        }

        private void MoveFieldFromOneListToAnother(string field, List<string> sourceList, List<string> destinationList)
        {
            sourceList.Remove(field);
            destinationList.Add(field);
        }

        public static bool ShipIsHit(string field, List<Player> players)
        {
            bool result = false;
            foreach (var player in players)
            {
                result = CheckFieldOnOccupiedList(field, player.Ships);
            }
            return result;
        }

        private static bool CheckFieldOnOccupiedList(string field, List<IShip> ships)
        {
            foreach (var ship in ships)
            {
                foreach (var position in ship.OccupiedPositions)
                {
                    if (position == field)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void ChangeActivePlayer(List<Player> players)
        {
            var index = players.FindIndex(p => p.IsActive == true);
            players[index].IsActive = false;
            if (index < players.Count() - 1)
            {
                players[index + 1].IsActive = true;
            }
            else
            {
                players[0].IsActive = true;
            }
        }

        private void SetActivePlayer(List<Player> players)
        {
            players.First(p => p.IsActive = true);
        }

        public static bool WhetherInactivePlayersHasShips(List<Player> players)
        {
            return players.Where(p => p.IsActive == false).Select(p => p.Ships).Select(p => p.Count > 0).Any();
        }
    }
}