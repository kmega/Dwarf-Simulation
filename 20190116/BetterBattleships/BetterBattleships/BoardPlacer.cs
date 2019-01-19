using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class BoardPlacer : IBoardPlacer
    {
        public void SetShipsOnBoard(CellStatus[,] Board, string Name)
        {
            List<ShipTypes> ListOfShipsToSet = new AvailableShips().GetShipList();
            ConsoleDisplayer consoleDisplayer = new ConsoleDisplayer();
            InputParser inputParser = new InputParser();

            consoleDisplayer.DisplayWhosBoard(Name);
            new ConsoleDisplayer().DisplayAvailableMovementPossibilities(new BoardFactory().Create());

            foreach (var ship in ListOfShipsToSet)
            {
                StartSettingSingleShip(Board, consoleDisplayer, inputParser, ship);
            }
            consoleDisplayer.DisplayPlayerHasFinishedSettingUpShips(Name);
            consoleDisplayer.ClearConsoleAndAwaitForAnyKey();
        }

        private void StartSettingSingleShip(CellStatus[,] Board, ConsoleDisplayer consoleDisplayer, InputParser inputParser, ShipTypes ship)
        {
            consoleDisplayer.DisplayTakenShip(ship);
            consoleDisplayer.DisplayBoardLegend();
            (int[] coords, string direction) = inputParser.ReturnAllValuesFromUserNeededToSetUpShip((int)ship);


            ExecuteShipPlacement(direction, coords, ship, Board);
            consoleDisplayer.DisplayBoard(Board);
        }

        public CellStatus GetCurrentCellStatus(int[] coords, CellStatus[,] Board)
        {
            return Board[coords[0], coords[1]];
        }

        public void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship, CellStatus[,] Board, bool testCondition = false)
        {
            if (direction == "w" || direction == "W")
            {
                int iteratingLength = 0;

                bool ifTrueThenSetShipOnBoard = true;
                for (int i = startCoords[0]; i >= 0; i--)
                {
                    if (Board[i, startCoords[1]] == CellStatus.DECK)
                    {
                        ifTrueThenSetShipOnBoard = false;
                        if (testCondition == true)
                        {
                            throw new Exception("Ship cant lay one on another");
                        }
                        break;
                    }
                }

                if(ifTrueThenSetShipOnBoard == false)
                {
                    Console.WriteLine("Statki nie moga na siebie nachodzic!");
                    Console.WriteLine("Powtorz ruch!");
                    new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                    StartSettingSingleShip(Board, new ConsoleDisplayer(), new InputParser(), ship);
                }

                if (ifTrueThenSetShipOnBoard == true)
                {
                    for (int i = startCoords[0]; i >= 0; i--)
                    {
                        Board[i, startCoords[1]] = CellStatus.DECK;

                        iteratingLength++;
                        if (iteratingLength == (int)ship)
                            break;
                    }
                }
            }

            if (direction == "s")
            {
                int iteratingLength = 0;
                for (int i = startCoords[0]; i <= 9; i++)
                {
                    if (Board[i, startCoords[1]] == CellStatus.DECK)
                    {
                        if (testCondition == true)
                        {
                            throw new Exception("Ship cant lay one on another"); //reukrencja
                        }
                        Console.WriteLine("Statki nie moga na siebie nachodzic!");
                        Console.WriteLine("Powtorz ruch!");
                        new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                        StartSettingSingleShip(Board, new ConsoleDisplayer(), new InputParser(), ship);
                    }

                    Board[i, startCoords[1]] = CellStatus.DECK;

                    iteratingLength++;
                    if (iteratingLength == (int)ship)
                        break;
                }
            }

            if (direction == "d")
            {
                int iteratingLength = 0;
                for (int i = startCoords[1]; i <= 9; i++)
                {
                    if (Board[startCoords[0], i] == CellStatus.DECK)
                    {
                        if (testCondition == true)
                        {
                            throw new Exception("Ship cant lay one on another"); //reukrencja
                        }
                        Console.WriteLine("Statki nie moga na siebie nachodzic!");
                        Console.WriteLine("Powtorz ruch!");
                        new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                        StartSettingSingleShip(Board, new ConsoleDisplayer(), new InputParser(), ship);
                    }

                    Board[startCoords[0], i] = CellStatus.DECK;

                    iteratingLength++;
                    if (iteratingLength == (int)ship)
                        break;
                }
            }

            if (direction == "a")
            {
                int iteratingLength = 0;
                for (int i = startCoords[1]; i >= 0; i--)
                {
                    if (Board[startCoords[0], i] == CellStatus.DECK)
                    {
                        if (testCondition == true)
                        {
                            throw new Exception("Ship cant lay one on another"); //reukrencja
                        }
                        Console.WriteLine("Statki nie moga na siebie nachodzic!");
                        Console.WriteLine("Powtorz ruch!");
                        new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                        StartSettingSingleShip(Board, new ConsoleDisplayer(), new InputParser(), ship);
                    }

                    Board[startCoords[0], i] = CellStatus.DECK;

                    iteratingLength++;
                    if (iteratingLength == (int)ship)
                        break;
                }
            }
        }
    }
}