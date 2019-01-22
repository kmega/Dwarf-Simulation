
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
        Game game;
        public bool IsShipBuildCorrectly = false;
        public string ShipType, ChoosingStartPointAfterValidation, Direction, NameOfPlayer, NameOfPlayer2;
        public UI()
        {
            game = new Game();
        }
        public List<Player> PreparePlayersGameBoard()
        {
            List<Player> players = new List<Player>()
            {
                new Player(),
                new Player()
            };
            GameRules();
            for (int i = 0; i < 2; i++)
            {                
                Console.Write($"Gracz {i + 1} podaj swoje imię: ");
                players[i].Name = Console.ReadLine();
                BuildShipsForSinglePlayer(players[i]);
                Console.WriteLine($"Plansza gracza nr {i + 1}: ");
                game.ShowPlayerBoardWithShips(players[i]);
                Console.ReadKey();
                Console.Clear();
            }
            return players;
        }
        

        public void BuildShipsForSinglePlayer(Player player)
        {
            Console.WriteLine();
            ChoosePlacesOfShips(player);
            Console.WriteLine();
        }

        public void ChoosePlacesOfShips(Player player)
        {
              //Change showPlayersBoardsWithShips from static to non static
            while (player.Ships.Count != 5)
            {
                game.ShowPlayersBoardsWithShips(new List<Player>() { player });
                ChooseTypeOfShip(player);
                ChooseStartPoint();
                ChooseDirection();
                
                SendTheDataToPlayer(player);
            }
            
        }
        //zasady gry 
        public static void ShowGameRules()
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
        public void SendTheDataToPlayer(Player player)
        {
            try
            {
                player.Ships.Add(shipfactory.Create(ShipType,
                    ChoosingStartPointAfterValidation.ToUpper(),
                    Direction, player));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ChooseDirection()
        {
            bool isDirectionCorrect = false;
            do
            {
                Console.WriteLine("Wybierz kierunek: (L - Left, R- Right, U - Up, D -Down");
                Direction = (Console.ReadLine()).ToLower();
                try
                {
                    isDirectionCorrect = InputValidator.CheckDirection(Direction);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (isDirectionCorrect == false);

        }
        public void ChooseStartPoint()
        {
            bool isStartPointCorrect = false;
            do
            {
                Console.WriteLine("Wybierz punkt startowy:");
                ChoosingStartPointAfterValidation = (Console.ReadLine()).ToLower();
                try
                {
                    isStartPointCorrect = InputValidator.CheckPosition(ChoosingStartPointAfterValidation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (isStartPointCorrect == false) ;
        }
        public void ChooseTypeOfShip(Player player)
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
            bool IsShipTypeCorrect = false;
            bool ShipExists = false;
            do
            {
                    Console.WriteLine("Wybierz rodzaj statku:");
                    ShipType = (Console.ReadLine()).ToLower();
                    try
                    {
                        IsShipTypeCorrect = InputValidator.CheckShipType(ShipType);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    ShipExists = InputValidator.CheckIfChoosenShipAlreadyExists(ShipType, player);
                if(ShipExists)
                {
                    Console.WriteLine("Ten typ statku już istnieje, wybierz inny!");
                }
            } while (IsShipTypeCorrect == false || ShipExists == true);
        }
        public static string InputFieldToAttack() //METODA ZWRÓCI STRING JEŻELI WPROWADZONE POLE JEST W PORZĄDKU
                                                 //JAK KTOŚ WPROWADZI BŁĘDNE POLE, RZUCA EXCEPTION
        {
            string attackthisfield;
            Console.Write("\nPodaj pole ataku: ");
            attackthisfield = Console.ReadLine().ToUpper();
            InputValidator.CheckIfYouCanAttackThisPosition(attackthisfield);
            return attackthisfield;

        }
    }
}


