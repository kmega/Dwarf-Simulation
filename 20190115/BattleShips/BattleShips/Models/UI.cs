
using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public class UI
    {
        public int boardsize = 10;
        Shipfactory shipfactory = new Shipfactory();
        Player player = new Player();
        public bool IsShipBuildCorrectly = false;
        bool IsShipTypeCorrect = false;
        public string ChoosingShipByPlayerAfterValidation, ChoosingStartPointAfterValidation, ChoosingDirectionByPlayerAfterValidation, NameOfPlayer,NameOfPlayer2;
        public UI()
        {
            List<Player> players = new List<Player> { };
            TheEarlyGame(players);  //choosing ships 
            TheGameStarts();
            Console.ReadKey();
        }

        public void TheGameStarts()
        {
            Console.WriteLine("Twoja plansza:");
            //generowanie planszy z gotowymi statkami
            Console.WriteLine("Plansza przeciwnika:");
            // generowanie planszy przeciwnika tylko ze strzałami
            Console.WriteLine("Wpisz pole, które chcesz zaatakować");
            //wyswietlenie planszy przeciwnika

        }

        public void TheEarlyGame(List<Player> players)
        {
             Console.WriteLine("Gracz 1- Podaj swoje imię:");
            NameOfPlayer = Console.ReadLine();
            player.Name = NameOfPlayer;
            GameRules();
            Console.WriteLine();       
            ChoosePlacesOfShips();           
            Console.WriteLine();
            BoardGenerate();
            Console.WriteLine("Gracz 2-Podaj swoje imię:");
            NameOfPlayer2 = Console.ReadLine();
            player.Name = NameOfPlayer2;
            ChoosePlacesOfShips();
            Console.WriteLine();
            BoardGenerate();

        }

        public void ChoosePlacesOfShips()
        {           
            for (int i = 0; i < 5; i++)
            {
                do
                { 
                ChooseTypeOfShip();
                ChooseStartPoint();
                ChooseDirection();
                SendTheDataToPlayer();

                } while (IsShipBuildCorrectly == false);
            }
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
        public void SendTheDataToPlayer()
        {
            do
            {
                try
                {
                    player.Ships.Add(shipfactory.Create(ChoosingShipByPlayerAfterValidation,
                        ChoosingStartPointAfterValidation.ToUpper(),
                        ChoosingDirectionByPlayerAfterValidation, player));
                    IsShipTypeCorrect = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    IsShipBuildCorrectly = false;
                }
            } while (IsShipBuildCorrectly == false);
        }
        public void ChooseDirection()
        {      
                do
                {
                        Console.WriteLine("Wybierz kierunek: (L - Left, R- Right, U - Up, D -Down");
                        ChoosingDirectionByPlayerAfterValidation = (Console.ReadLine()).ToLower();
                try
                {
                    IsShipTypeCorrect = InputValidator.CheckPosition(ChoosingStartPointAfterValidation);
                    IsShipTypeCorrect = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    IsShipTypeCorrect = false;
                }

            } while (IsShipTypeCorrect == false);
          
        }
        public void ChooseStartPoint()
        {
            try
            {
                do
                {
                    Console.WriteLine("Wybierz punkt startowy:");
                    ChoosingStartPointAfterValidation = (Console.ReadLine()).ToLower();
                    try
                    {
                        IsShipTypeCorrect = InputValidator.CheckPosition(ChoosingStartPointAfterValidation);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        IsShipTypeCorrect = false;
                    }
                } while (IsShipTypeCorrect == false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IsShipTypeCorrect = false;
            }     
        }          
    public void ChooseTypeOfShip()
        {
              List<string> TypeOfShips = new List<string> { "C- CARRIER (pięciomasztowiec o wielkości 5 pól)\n",
                "B- BATTLESHIP (czteromasztowiec o wielkości 4 pól) \n",
                "D- DESTROYER (trzymasztowiec o wielkości 3 pól)\n",
                "S- SUBMARINE (trzymasztowiec o wielkości 3 pól)\n",
                "P- PATROL BOAT (dwumasztowiec o wielkości 2 pól)" };
                Console.WriteLine("Wybierz rodzaj statku, który chcesz zamieścić na planszy: (Wpisz odpowiednią literę\n");
                foreach (string x in TypeOfShips)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine();
                BoardGenerate();
                bool IsShipTypeCorrect = false;
                bool IsShipExist = true;
                do
                {
                do
                {
                    Console.WriteLine("Wybierz rodzaj statku:");
                    ChoosingShipByPlayerAfterValidation = (Console.ReadLine()).ToLower();
                    try
                    {
                        IsShipTypeCorrect = InputValidator.CheckShipType(ChoosingShipByPlayerAfterValidation);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        IsShipTypeCorrect = false;
                    }
                    IsShipExist = InputValidator.CheckIfChoosenShipAlreadyExists(ChoosingShipByPlayerAfterValidation, player);
                } while (IsShipExist == true);
                } while (IsShipTypeCorrect == false);         
        }
        public void BoardGenerate()
        {
            string[,] array = new string[10, 10];
            TextParser.FillArray(array, "- ");
            //string field = "";
            List<string> PlaceWithShip = new List<string>() {};
            //foreach (string x in occupiedPositions) //przeslac gracza do tego, dokopac sie 
            //PlaceWithShip.Add(ChoosingStartPointAfterValidation = (Console.ReadLine()).ToLower());          
            foreach (var item in PlaceWithShip)
            {
                TextParser.FillArrayWithShip(array, item);
            }
            TextParser.DrawArray(array);

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


