using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class InputParser : IInput
    {
        public string GetNameForNewPlayer()
        {
            Console.Write("Podaj imie: ");
            return Console.ReadLine();
        }

        public int[] GetCoordinatesToSetShip()
        {
            Console.WriteLine();
            Console.WriteLine("Podaj punkt pcozatkowy statku: ");
            Console.Write("Podaj rzad {0-9}: ");

            int row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Podaj kolumna {0-9}: ");

            int column = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, column };
        }

        public string GetDirectionsForCoordinates()
        {
            Console.WriteLine("Statki nie moga na siebie nachodzic");
            Console.Write("Wpisz kierunek: ");
            return Console.ReadLine();
        }

        public int[] GetCoordinatesToShootShip(string vicitmName, string shooter)
        {
            Console.WriteLine("Strzela gracz: {0}, jesli trafi w pole typu Deck, to moze wykonac ponowny ruch", shooter);
            Console.WriteLine();
            Console.WriteLine("Podaj punkt gdzie chcesz wykonac strzal w plansze gracza: {0}", vicitmName);
            Console.Write("Podaj rzad {0-9}: ");

            int row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Podaj kolumna {0-9}: ");

            int column = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, column };
        }
    }
}