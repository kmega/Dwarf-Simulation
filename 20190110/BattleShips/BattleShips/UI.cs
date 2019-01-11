using BattleShip;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    public class UI
    {
        public int boardsize = 10;
        
        UIvalidation validation = new UIvalidation();
        ShipFactory shipfactory = new ShipFactory();
        Player player = new Player();
        string ChoosingShipByPlayerAfterValidation, ChoosingStartPointAfterValidation, ChoosingDirectionByPlayerAfterValidation, NameOfPlayer;
        public UI()
        {
            
            GameRules();
            Console.WriteLine();        
            ChooseTypeOfShip();
            Console.WriteLine();
            BoardGenerate();

            Console.ReadKey();
        }


        //zasady gry 
        public void GameRules()
        {
            Console.WriteLine("ZASADY GRY \nKażdy z graczy posiada po dwie plansze o wielkości 10x10 pól.\n" +
                "Kolumny są oznaczone poprzez współrzędne literami od A do J i liczbami 1 do 10. \n" +
                "Na jednym z kwadratów gracz zaznacza swoje statki, których położenie będzie odgadywał przeciwnik. \n" +
                "Na drugim zaznacza trafione statki przeciwnika i oddane przez siebie strzały. \n" +
                "Statki ustawiane są w pionie lub poziomie, w taki sposób, aby nie stykały się one ze sobą ani bokami, ani rogami.\n" +
                "Trafienie okrętu przeciwnika polega na strzale, który jest odgadnięciem położenia jakiegoś statku.\n" +
                "Strzały oddawane są naprzemiennie, poprzez podanie współrzędnych pola(np.B5).\n" +
                "W przypadku strzału trafionego, gracz kontynuuje strzelanie(czyli swój ruch) aż do momentu chybienia.\n" +
                "Zatopienie statku ma miejsce wówczas, gdy gracz odgadnie położenie całego statku.\n" +
                "O chybieniu interfejs informuje użytkownika słowem „Pudło”, o trafieniu „Trafiony” lub „(Trafiony)Zatopiony”.\n" +
                "Wygrywa ten, kto pierwszy zatopi wszystkie statki przeciwnika.");

        }


        //jak wprowadzac statek

        public void ChooseTypeOfShip()
        {
            Console.WriteLine("Podaj swoje imię:");
            NameOfPlayer = Console.ReadLine();
            player.PlayerName = NameOfPlayer;
            
            List<string> TypeOfShips = new List<string> { "A- CARRIER (pięciomasztowiec o wielkości 5 pól)\n",
                "B- BATTLESHIP (czteromasztowiec o wielkości 4 pól) \n",
                "D- DESTROYER (trzymasztowiec o wielkości 3 pól)\n",
                "S- SUBMARINE (trzymasztowiec o wielkości 3 pól)\n",
                "P- PATROL BOAT (dwumasztowiec o wielkości 2 pól)" };
            Console.WriteLine("Wybierz rodzaj statku, który chcesz zamieścić na planszy: (Wpisz odpowiednią literę\n");
            foreach (string x in TypeOfShips)
            {
                Console.WriteLine(x);
            }
            //choosenshipbyplayergotovalidation = Console.ReadLine();
            ChoosingShipByPlayerAfterValidation = validation.TypeOfShipValidation();
            Console.WriteLine("Wybierz punkt startowy:");
            ChoosingStartPointAfterValidation = validation.StartPointValidation();
            Console.WriteLine("Wybierz kierunek: (L - Left, R- Right, U - Up, D -Down");
            ChoosingDirectionByPlayerAfterValidation = validation.DirectionValidation();
            shipfactory.PlaceSingleShip(ChoosingShipByPlayerAfterValidation, ChoosingStartPointAfterValidation, ChoosingDirectionByPlayerAfterValidation, player);
            
            //playername podeslac
            //PlaceSingleShip(string shipType, string startingPoint, string direction, Player player)
          // wyslac do shipfactory = wyslac do playera.
        }

        // pusta plansza
        public void BoardGenerate()
        {
            List<string> ZeroRow = new List<string> { "  ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            List<string> FirstRow = new List<string> { "1 ", };
            List<string> SecondRow = new List<string> { "2 ", };
            List<string> ThirdRow = new List<string> { "3 ", };
            List<string> FourthRow = new List<string> { "4 ", };
            List<string> FifthRow = new List<string> { "5 ", };
            List<string> SixthRow = new List<string> { "6 ", };
            List<string> SeventhRow = new List<string> { "7 ", };
            List<string> EightRow = new List<string> { "8 ", };
            List<string> NineRow = new List<string> { "9 ", };
            List<string> TenRow = new List<string> { "10", };
            List<List<string>> ListOfBoardElements = new List<List<string>> { ZeroRow, FirstRow, SecondRow, ThirdRow, FourthRow, FifthRow, SixthRow, SeventhRow, EightRow, NineRow, TenRow };

            for (int i = 0; i < ListOfBoardElements.Count; i++)
            {

                for (int j = 0; j < ListOfBoardElements[i].Count; j++)
                {
                    if (ListOfBoardElements[i].Count < ListOfBoardElements.Count)
                    {
                        ListOfBoardElements[i].Add("*");
                    }
                }
            }

            for (int i = 0; i < ListOfBoardElements.Count; i++)
            {

                Console.WriteLine("--------------------------------------------");

                for (int j = 0; j < ListOfBoardElements[i].Count; j++)
                {

                    Console.Write(ListOfBoardElements[i][j] + " | ");

                }
                Console.WriteLine();


            }
            Console.WriteLine("--------------------------------------------");

        }

      
        //}
        // wybierz statek / prawo lewo pole
        //czy wybrales dobre pole - wybierz jeszcze raz
        //nie mozesz wybrac statku w polu obok
        //pokaż plansze/ twoja/przeciwnika
        // strzal
        //zmien strzal na symbol
        //jezeli pole sie powtorzy juz tam strzelales
        //koncza sie statki - wygrales/przegrales endgame

    }
}

