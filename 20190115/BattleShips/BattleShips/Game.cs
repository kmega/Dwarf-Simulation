using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public class Game
    {
        public List<Player> Players { get; set; }

        #region Start Game
        public void StartGame()
        {
            UI.ShowGameRules();
            Players = new UI().PreparePlayersGameBoard();
            ShowPlayersBoards(Players);
            Console.WriteLine("\nPress any key to start game\n");
            Console.ReadKey();
            Console.Clear();
            
            SetActivePlayer(Players);
            while (WhetherInactivePlayersHasShips(Players))
            {
                var field = UI.InputFieldToAttack();

                MakeTurnInGame(Players, field);
                ShowPlayersBoardsWithChoosenFields(Players);
            }
            var activePlayer = Players.Where(p => p.IsActive == true).First();
            Console.WriteLine($"The winner is: " + activePlayer.IsActive);
        }
        #endregion

        public void ChangeActivePlayer(List<Player> players)
        {
            var index = players.FindIndex(p => p.IsActive == true);
            players[index].IsActive = false;
            if (index < players.Count() - 1)
            {
                players[index + 1].IsActive = true;
                Console.WriteLine($"\n{players[index + 1].Name} turn\n");
            }
            else
            {
                players[0].IsActive = true;
                Console.WriteLine($"\n{players[index + 1].Name} turn\n");
            }
        }

        public bool CheckFieldOnOccupiedShipList(string field, List<IShip> ships)
        {
            foreach (var ship in ships)
            {
                foreach (var position in ship.OccupiedPositions)
                {
                    if (position.Equals(field))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckIfShipIsHit(string field, List<Player> players)
        {
            bool result = false;
            foreach (var player in players)
            {
                result = CheckFieldOnOccupiedShipList(field, player.Ships);
            }
            return result;
        }

        public void CreateEmptyBoard(string[,] board)
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

        public static void FillPlayerBoardByChoosenFields(Player player, string[,] board)
        {
            foreach (var field in player.ChoosenFields)
            {
                int x, y;
                ParseFieldToInt(field, out x, out y);
                board[x, y] = "o ";
            }
        }

        public static void FillPlayerBoardByDestroyedShips(Player player, string[,] board)

        {
            foreach (var ship in player.Ships)
            {
                foreach (var field in ship.DamagedPositions)
                {
                    int x, y;
                    ParseFieldToInt(field, out x, out y);
                    board[y, x] = "X ";
                }
            }
        }

        public static void FillPlayerBoardByShips(Player player, string[,] board)
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

        public static void ParseFieldToInt(string field, out int x, out int y)
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

        public static void ShowBoard(string[,] board)

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

        public void ShowPlayerBoardWithChoosenFieldsAndDestroyerShips(Player player)
        {
            string[,] board = new string[10, 10];
            CreateEmptyBoard(board);
            FillPlayerBoardByChoosenFields(player, board);
            FillPlayerBoardByDestroyedShips(player, board);
            ShowBoard(board);
        }

        public void ShowPlayerBoardWithChoosenFieldsAndShips(Player player)
        {
            string[,] board = new string[10, 10];
            CreateEmptyBoard(board);
            FillPlayerBoardByChoosenFields(player, board);
            FillPlayerBoardByShips(player, board);
            ShowBoard(board);
        }

        public void ShowPlayerBoardWithShips(Player player)
        {
            string[,] board = new string[10, 10];
            CreateEmptyBoard(board);
            FillPlayerBoardByShips(player, board);
            ShowBoard(board);
        }

        public void ShowPlayersBoards(List<Player> players)
        {
            foreach (var player in players)
            {
                ShowPlayerBoardWithChoosenFieldsAndShips(player);
                Console.WriteLine("");
            }
        }

        public void ShowPlayersBoardsWithShips(List<Player> players)
        {
            foreach (var player in players)
            {
                ShowPlayerBoardWithShips(player);
                Console.WriteLine("");
            }
        }

        public static bool WhetherInactivePlayersHasShips(List<Player> players)
        {
            return players.Where(p => p.IsActive == false).Select(p => p.Ships).Select(p => p.Count > 0).Any();
        }

        public List<Player> CreateInactivePlayersList(List<Player> players)
        {
            return players.Where(p => p.IsActive == false).ToList();
        }

        public void MakeTurnInGame(List<Player> players, string field)
        {
            var inactivePlayers = CreateInactivePlayersList(players);
            if (CheckIfShipIsHit(field, inactivePlayers))
            {
                Console.WriteLine("\nShip has been hit\n");
                foreach (var player in inactivePlayers)
                {
                    foreach (var ship in player.Ships)
                    {
                        if (ship.OccupiedPositions.Contains(field))
                        {
                            MoveFieldFromOneListToAnother(field, ship.OccupiedPositions, ship.DamagedPositions);
                        }

                        if (ship.OccupiedPositions.Count() == 0)
                        {
                            Console.WriteLine($"\nThe ship {ship.Type} has been destroyed\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You missed :-)");
                ChangeActivePlayer(players);
            }
        }

        public void MoveFieldFromOneListToAnother(string field, List<string> sourceList, List<string> destinationList)
        {
            sourceList.Remove(field);
            destinationList.Add(field);
        }

        public void SetActivePlayer(List<Player> players)
        {
            var player = players.First(p => p.IsActive = true);
            Console.WriteLine($"\n{player.Name} starts game");
        }

        public void ShowPlayersBoardsWithChoosenFields(List<Player> players)
        {
            foreach (var player in players)
            {
                ShowPlayerBoardWithChoosenFieldsAndDestroyerShips(player);
                Console.WriteLine("");
            }
        }

        
    }
}