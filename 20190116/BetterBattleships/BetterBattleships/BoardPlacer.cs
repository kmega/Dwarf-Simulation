using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class BoardPlacer : IBoardPlacer
    {
        public void SetShipsOnBoard(CellStatus[,] Board, string Name)
        {
            List<ShipTypes> ListOfShipsToSet = new AvailableShips().GetShipList();
            var consoleDisplayer = new ConsoleDisplayer();

            consoleDisplayer.DisplayWhosBoard(Name);
            foreach (var ship in ListOfShipsToSet)
            {
                consoleDisplayer.DisplayTakenShip(ship);
                string direction = GetDirectionsForCoordinates();
                int[] coords = GetCoordinatesToSetShip();

                ExecuteShipPlacement(direction, coords, ship, Board);
                consoleDisplayer.DisplayBoard(Board);
            }
            consoleDisplayer.PlayerHasFinishedSettingUpShips(Name);
            consoleDisplayer.ClearConsoleAndAwaitForAnyKey();
        }

        public int[] GetCoordinatesToSetShip()
        {
            Console.WriteLine("Podaj punkt pcozatkowy statku: ");
            Console.WriteLine("Podaj rzad: {0-9}");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj kolumna: {0-9}");
            int column = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, column };
        }

        public string GetDirectionsForCoordinates()
        {
            new ConsoleDisplayer().DisplayAvailableMovementPossibilities();
            return System.Console.ReadLine();
        }

        public CellStatus GetCurrentCellStatus(int[] coords, CellStatus[,] Board)
        {
            return Board[coords[0], coords[1]];
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

            if (direction == "a")
            {
                int temp = 0;
                for (int i = startCoords[1]; i >= 0; i--)
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