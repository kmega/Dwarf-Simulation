using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public void StartGame()
        {
            ShowPlayersBoards(Players);

            SetActivePlayer(Players);
            while (WhetherInactivePlayersHasShips(Players))
            {
                string field = "A0"; //field input by active player
                UI.InputFieldToAttack();
                var inactivePlayers = CreateInactivePlayersList(Players);
                Turn(inactivePlayers, field);
            }
            var activePlayer = Players.Where(p => p.IsActive == true).First();
            Console.WriteLine($"The winner is: " + activePlayer.IsActive);
        }


        public static void ShowPlayersBoards(List<Player> players)
        {
            foreach (var player in players)
            {
                CreatePlayerBoard(player);
                Console.WriteLine("");
            }
        }

        private static void CreatePlayerBoard(Player player)
        {
            string[,] board = new string[10, 10];
            CreateEmptyBoard(board);
            FillArrayPlayerChoosenFields(player, board);
            FillArrayPlayerShips(player, board);
            ShowBoard(board);
        }

        private static void FillArrayPlayerChoosenFields(Player player, string[,] board)
        {
            foreach (var field in player.ChoosenFields)
            {
                int x, y;
                ParseFieldToInt(field, out x, out y);
                board[x, y] = "o ";
            }
        }

        private static void FillArrayPlayerShips(Player player, string[,] board)

        {
            foreach (var ship in player.Ships)
            {
                foreach (var field in ship.OccupiedPositions)
                {
                    int x, y;
                    ParseFieldToInt(field, out x, out y);
                    board[y, x] = "X ";
                }
            }
        }

        private static void ParseFieldToInt(string field, out int x, out int y)
        {
            x = field[0] - 65;
            if (field.Length == 2)
            {
                y = Convert.ToInt32(field[1]) - 49;
            }
            else
            {
                y = Int32.Parse($"{field[1]}{field[2]}") - 1;
            }
        }

        private static void ShowBoard(string[,] board)

        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine("");
            }
        }

        public static void CreateEmptyBoard(string[,] board)
        {
            var symbol = "- ";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = symbol;
                }
            }
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