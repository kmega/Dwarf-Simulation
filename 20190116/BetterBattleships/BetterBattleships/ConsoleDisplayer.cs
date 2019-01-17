using System;

namespace BetterBattleships
{
    public class ConsoleDisplayer
    {
        public void DisplayBoard(CellStatus[,] Board)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    var uglyLongVar = new BoardPlacer().GetCurrentCellStatus(new int[] { i, j }, Board);
                    System.Console.Write("[{0}] ", (char)uglyLongVar);
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        public void DisplayWhosBoard(string Name)
        {
            System.Console.WriteLine("Plansza gracza: {0}", Name);
            System.Console.WriteLine();
        }

        public void DisplayTakenShip(ShipTypes ship)
        {
            System.Console.WriteLine($"Wybrany statek: {ship}");
        }

        public void DisplayAvailableMovementPossibilities()
        {
            Console.WriteLine("Podaj kierunek: ");
            Console.WriteLine("a - lewo");
            Console.WriteLine("d - prawo");
            Console.WriteLine("w - gora");
            Console.WriteLine("s - dol");
        }

        public void ClearConsoleAndAwaitForAnyKey()
        {
            Console.Clear();
        }

        public void PlayerHasFinishedSettingUpShips(string Name)
        {
            Console.WriteLine($"{Name} zakonczyl wypelnianie tablicy");
            Console.WriteLine("Nacisnij dodowlny klawisz by kontynuowac...");
            Console.ReadKey();
        }
    }
}







