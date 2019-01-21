using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Podaj punkt poczatkowy statku");

            int[] coordsFromKeyboard = ParseCorrectnessOfInputCoordsFromKeyboard();

            return coordsFromKeyboard;
        }

        public int[] ParseCorrectnessOfInputCoordsFromKeyboard(bool testCondition = false, string testInput = null)
        {
            Console.Write("Podaj kooordynaty w formacie (LiteraNumer): ");
            string inputFromKeyboard = testInput;

            if (testCondition == false)
            {
                inputFromKeyboard = Console.ReadLine();
                Console.WriteLine();
            }

            if (inputFromKeyboard.Length > 2)
                throw new ArgumentOutOfRangeException();
            if(inputFromKeyboard.Length == 1 || inputFromKeyboard == "")
                ParseCorrectnessOfInputCoordsFromKeyboard();

            int firstArrayValue = 100;
            int secondArrayValue = 100;

            switch (inputFromKeyboard[0].ToString().ToLower())
            {
                case "a":
                    firstArrayValue = 0;
                    break;
                case "b":
                    firstArrayValue = 1;
                    break;
                case "c":
                    firstArrayValue = 2;
                    break;
                case "d":
                    firstArrayValue = 3;
                    break;
                case "e":
                    firstArrayValue = 4;
                    break;
                case "f":
                    firstArrayValue = 5;
                    break;
                case "g":
                    firstArrayValue = 6;
                    break;
                case "h":
                    firstArrayValue = 7;
                    break;
                case "i":
                    firstArrayValue = 8;
                    break;
                case "j":
                    firstArrayValue = 9;
                    break;

                default:
                    if (testCondition == true)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine("Podales zly format!");
                    Console.WriteLine("Zeby wprowadzic dane jeszcze raz, to nacisnij dowolny klawisz...");
                    Console.ReadKey();
                    Console.Clear();
                    ParseCorrectnessOfInputCoordsFromKeyboard();
                    break;
            }

            switch (inputFromKeyboard[1].ToString())
            {
                case "0":
                    secondArrayValue = 0;
                    break;
                case "1":
                    secondArrayValue = 1;
                    break;
                case "2":
                    secondArrayValue = 2;
                    break;
                case "3":
                    secondArrayValue = 3;
                    break;
                case "4":
                    secondArrayValue = 4;
                    break;
                case "5":
                    secondArrayValue = 5;
                    break;
                case "6":
                    secondArrayValue = 6;
                    break;
                case "7":
                    secondArrayValue = 7;
                    break;
                case "8":
                    secondArrayValue = 8;
                    break;
                case "9":
                    secondArrayValue = 9;
                    break;

                default:
                    if(testCondition == true)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine("Podales zly format!");
                    Console.WriteLine("Zeby wprowadzic dane jeszcze raz, to nacisnij dowolny klawisz...");
                    Console.ReadKey();
                    Console.Clear();
                    ParseCorrectnessOfInputCoordsFromKeyboard();
                    break;
            }

            return new int[] { firstArrayValue, secondArrayValue };
        }

        internal (int[] coords, string direction) ReturnAllValuesFromUserNeededToSetUpShip(int shipLength)
        {
            int[] coords = GetCoordinatesToSetShip();
            string direction = GetDirectionsForCoordinates(coords, (int)shipLength);

            return (coords, direction);
        }

        public string GetDirectionsForCoordinates(int[] coords, int shipLength)
        {
            Console.WriteLine("Pamietaj, statki nie moga na siebie nachodzic");
            Console.Write("Wpisz kierunek: ");
            string directionFromKeyboard = Console.ReadLine();

            if (directionFromKeyboard != "a" &&
                directionFromKeyboard != "A" &&
                directionFromKeyboard != "w" &&
                directionFromKeyboard != "W" &&
                directionFromKeyboard != "s" &&
                directionFromKeyboard != "S" &&
                directionFromKeyboard != "d" &&
                directionFromKeyboard != "D")
            {
                ReturnAllValuesFromUserNeededToSetUpShip(shipLength);
            }

            if (directionFromKeyboard == "a" || directionFromKeyboard == "A")
            {
                if (coords[1] - (shipLength - 1) < 0)
                {
                    Console.WriteLine("Statek w tym kierunku nie zmiesci sie na planszy, wprowadz kierunek i wspolrzedne jeszcze raz!");
                    new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                    directionFromKeyboard = GetDirectionsForCoordinates(coords, shipLength);
                }
            }
            else if (directionFromKeyboard == "d" || directionFromKeyboard == "D")
            {
                if (coords[1] + (shipLength - 1) > 9)
                {
                    Console.WriteLine("Statek w tym kierunku nie zmiesci sie na planszy, wprowadz kierunek i wspolrzedne jeszcze raz!");
                    new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                    directionFromKeyboard = GetDirectionsForCoordinates(coords, shipLength);          
                }
            }
            else if (directionFromKeyboard == "w" || directionFromKeyboard == "W")
            {
                if (coords[0] - (shipLength-1) < 0)
                {
                    Console.WriteLine("Statek w tym kierunku nie zmiesci sie na planszy, wprowadz kierunek i wspolrzedne jeszcze raz!");
                    new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                    directionFromKeyboard = GetDirectionsForCoordinates(coords, shipLength);
                }
            }
            else if (directionFromKeyboard == "s" || directionFromKeyboard == "S")
            {
                if (coords[0] + (shipLength - 1) > 9)
                {
                    Console.WriteLine("Statek w tym kierunku nie zmiesci sie na planszy, wprowadz kierunek i wspolrzedne jeszcze raz!");
                    new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
                    directionFromKeyboard = GetDirectionsForCoordinates(coords, shipLength);
                }
            }

            return directionFromKeyboard;

        }

        public int[] GetCoordinatesToShootShip(string vicitmName, string shooter)
        {
            Console.WriteLine("Strzela gracz: {0}, jesli trafi w pole typu Deck, to moze wykonac ponowny ruch", shooter);
            Console.WriteLine();
            Console.WriteLine("Podaj punkt gdzie chcesz wykonac strzal w plansze gracza: {0}", vicitmName);

            int[] coordsFromKeyboard = ParseCorrectnessOfInputCoordsFromKeyboard();

            return coordsFromKeyboard;
        }
    }
}