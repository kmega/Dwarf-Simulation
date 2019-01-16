using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class GameManager : IGameManager
    {
        public void SetShipsOnBoard(IPlayer player)
        {
            List<ShipTypes> ListOfShipsToSet = new AvailableShips().GetShipList();
            var cd = new ConsoleDisplay();

            foreach (var ship in ListOfShipsToSet)
            {
                string direction = GetDirectionsForCoordinates();
                int[] coords = GetCoordinatesToSetShip();

                ExecuteShipPlacement(direction, coords, ship, player);
                cd.DisplayBoard(player);
            }
        }

        public int[] GetCoordinatesToSetShip()
        {
            System.Console.WriteLine("Podaj punkt pcozatkowy statku: ");
            int row = Convert.ToInt32(Console.ReadLine());
            int column = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, column };
        }

        public CellStatus GetCurrentCellStatus(int[] coords, IPlayer player)
        {
            return player.GetBoard()[coords[0], coords[1]];
        }

        public string GetDirectionsForCoordinates()
        {
            System.Console.WriteLine("Podaj kierunek: ");
            return System.Console.ReadLine();
        }

        public void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship, IPlayer player)
        {
            if (direction == "w")
            {
                int temp = 0;
                for (int i = startCoords[0]; i >= 0; i--)
                {
                    if (player.GetBoard()[i, startCoords[1]] == CellStatus.DECK)
                        throw new System.NotImplementedException();

                    player.GetBoard()[i, startCoords[1]] = CellStatus.DECK;

                    temp++;
                    if (temp == (int)ship)
                        break;
                }
            }

            if (direction == "s")
            {
                int temp = 0;
                for (int i = startCoords[0]; i <= 9; i++)
                {
                    if (player.GetBoard()[i, startCoords[1]] == CellStatus.DECK)
                        throw new System.NotImplementedException();

                    player.GetBoard()[i, startCoords[1]] = CellStatus.DECK;

                    temp++;
                    if (temp == (int)ship)
                        break;
                }
            }

            if (direction == "d")
            {
                int temp = 0;
                for (int i = startCoords[1]; i <= 9; i++)
                {
                    if (player.GetBoard()[startCoords[0], i] == CellStatus.DECK)
                        throw new System.NotImplementedException();

                    player.GetBoard()[startCoords[0], i] = CellStatus.DECK;

                    temp++;
                    if (temp == (int)ship)
                        break;
                }
            }
        }
    }
}