using System;

namespace BetterBattleships
{
    public class ConsoleDisplayer
    {
        public void DisplayBoard(CellStatus[,] Board)
        {
            DisplayNumbersHorizontalAboveTheBoard();
            Console.WriteLine();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.Write("");
                DisplayVerticalLettersNextToBoard(i);
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    var uglyLongVar = new BoardPlacer().GetCurrentCellStatus(new int[] { i, j }, Board);
                    System.Console.Write("[{0}] ", (char)uglyLongVar);
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        public void DisplayWinnerAndEndGame(IPlayer winner)
        {
            Console.Clear();
            Console.WriteLine("Gra zakonczona!!!");
            Console.WriteLine("Zwyciezyl gracz {0} poprzez zniszczenie wszystkich statkow na planszy przeciwnika.", winner.Name);
            Console.WriteLine("Nacisnij dowlony klawisz by zamknac stateczki");
        }

        private static void DisplayNumbersHorizontalAboveTheBoard()
        {
            Console.Write("+ " );
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(" {0}  ", i);
            }
        }

        private void DisplayVerticalLettersNextToBoard(int i)
        {
            switch(i)
            {
                case 0:
                    Console.Write("A ");
                    break;
                case 1:
                    Console.Write("B ");
                    break;
                case 2:
                    Console.Write("C ");
                    break;
                case 3:
                    Console.Write("D ");
                    break;
                case 4:
                    Console.Write("E ");
                    break;
                case 5:
                    Console.Write("F ");
                    break;
                case 6:
                    Console.Write("G ");
                    break;
                case 7:
                    Console.Write("H ");
                    break;
                case 8:
                    Console.Write("I ");
                    break;
                case 9:
                    Console.Write("J ");
                    break;
            }
        }

        public void DisplayWhosBoard(string Name)
        {
            System.Console.WriteLine("Plansza gracza: {0}", Name);
            System.Console.WriteLine();
        }

        public void DisplayTakenShip(ShipTypes ship)
        {
            System.Console.WriteLine($"Wybrany statek: {ship}, dlugosc: {(int)ship}");
            Console.WriteLine();
        }

        public void DisplayAvailableMovementPossibilities(CellStatus[,] board)
        {
            Console.WriteLine("Podaj kierunek: ");
            Console.WriteLine("\ta - lewo");
            Console.WriteLine("\td - prawo");
            Console.WriteLine("\tw - gora");
            Console.WriteLine("\ts - dol");
            Console.WriteLine();
            DisplayBoard(board);
        }

        public void ClearConsoleAndAwaitForAnyKey()
        {
            Console.Clear();
        }

        public void DisplayPlayerHasFinishedSettingUpShips(string Name)
        {
            Console.WriteLine($"{Name} zakonczyl wypelnianie tablicy");
            Console.WriteLine("Nacisnij dodowlny klawisz by kontynuowac...");
            Console.ReadKey();
        }

        public void DisplayBoardLegend()
        {
            Console.WriteLine("Legenda tablicy gry, znaczenie sybolow na tablicy gry");
            Console.WriteLine("\tPuste pole = puste nawiasy kwadratowe");
            Console.WriteLine("\tStatek = {0}", (char)CellStatus.DECK);
            Console.WriteLine("\tTrafiony strzal w statek = {0}", (char)CellStatus.HIT);
            Console.WriteLine("\tNietrafiony strzal w statek = {0}", (char)CellStatus.MISS);
            Console.WriteLine();
        }
    }
}







