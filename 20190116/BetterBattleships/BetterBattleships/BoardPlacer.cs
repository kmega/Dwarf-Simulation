using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class BoardPlacer : IBoardPlacer
    {
        public void SetShipsOnBoard(CellStatus[,] Board)
        {
            List<ShipTypes> ListOfShipsToSet = new AvailableShips().GetShipList();
            var cd = new ConsoleDisplayer();

            foreach (var ship in ListOfShipsToSet)
            {
                string direction = GetDirectionsForCoordinates();
                int[] coords = GetCoordinatesToSetShip();

                ExecuteShipPlacement(direction, coords, ship, Board);
                cd.DisplayBoard(Board);
            }
        }

        public int[] GetCoordinatesToSetShip()
        {
            System.Console.WriteLine("Podaj punkt pcozatkowy statku: ");
            int row = Convert.ToInt32(Console.ReadLine());
            int column = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, column };
        }

        public CellStatus GetCurrentCellStatus(int[] coords, CellStatus[,] Board)
        {
            return Board[coords[0], coords[1]];
        }

        public string GetDirectionsForCoordinates()
        {
            System.Console.WriteLine("Podaj kierunek: ");
            return System.Console.ReadLine();
        }

        public void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship, CellStatus[,] Board)
        {
            if (direction == "w")
            {
                int temp = 0;
                for (int i = startCoords[0]; i >= 0; i--)
                {
                    if (Board[i, startCoords[1]] == CellStatus.DECK)
                        throw new System.NotImplementedException();

                    Board[i, startCoords[1]] = CellStatus.DECK;

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
                    if (Board[i, startCoords[1]] == CellStatus.DECK)
                        throw new System.NotImplementedException();

                    Board[i, startCoords[1]] = CellStatus.DECK;

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
                    if (Board[startCoords[0], i] == CellStatus.DECK)
                        throw new System.NotImplementedException();

                    Board[startCoords[0], i] = CellStatus.DECK;

                    temp++;
                    if (temp == (int)ship)
                        break;
                }
            }
        }
    }
}