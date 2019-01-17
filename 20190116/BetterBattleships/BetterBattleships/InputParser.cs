using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class InputParser : IInput
    {
        public string GetNameForNewPlayer()
        {
            Console.WriteLine("Podaj imie: ");
            return System.Console.ReadLine();
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
            return Console.ReadLine();
        }

        public int[] GetCoordinatesToShootShip(string name)
        {
            Console.WriteLine("Podaj punkt gdzie chcesz wykonac strzal w plansze gracza: {0}", name);
            Console.WriteLine("Podaj rzad: {0-9}");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj kolumna: {0-9}");
            int column = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, column };
        }
    }
}