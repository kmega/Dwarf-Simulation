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
            var inputParser = new InputParser();

            consoleDisplayer.DisplayWhosBoard(Name);
            foreach (var ship in ListOfShipsToSet)
            {
                consoleDisplayer.DisplayTakenShip(ship);
                string direction = inputParser.GetDirectionsForCoordinates();
                int[] coords = inputParser.GetCoordinatesToSetShip();

                ExecuteShipPlacement(direction, coords, ship, Board);
                consoleDisplayer.DisplayBoard(Board);
            }
            consoleDisplayer.PlayerHasFinishedSettingUpShips(Name);
            consoleDisplayer.ClearConsoleAndAwaitForAnyKey();
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