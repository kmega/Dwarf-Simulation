using System;
using System.Collections.Generic;
using barcos.Enums;

namespace barcos
{
    public class Hypervisor
    {
        public int TurnCounter; // ??????
        public GameState GameState;
        public List<Player> Players;

        public Hypervisor()
        {
            Players = new List<Player>();
        }


        public void CheckPlayersShipsState()
        {

        }

        public void CheckIfPlayerHitsShip()
        {

        }

        public void ChangeActivePlayer()
        {

        }


        public void InitiatePlayers(string playerName_1, string playerName_2)
        {
            string[] players = new string[2] { playerName_1, playerName_2 };
            int i = 0;

            foreach(Player player in Players)
            {
                player.Name = players[i];

                Console.WriteLine("{0} locate Your ships on the board:", player.Name);

                foreach (var ship in player.Ships)
                {
                    Console.WriteLine("Set ship {0} masts coordinate X: ", ship.Masts);
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Set ship {0} masts coordinate Y: ", ship.Masts);
                    int y = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Would You like to place Your ship horizontally(0) or vertically(1)?");
                    int orientation = Convert.ToInt32(Console.ReadLine());

                    if (orientation == 0)
                    player.SetShipsOnBoard(ship, x, y, ShipOrientation.horizontally);
                    else player.SetShipsOnBoard(ship, x, y, ShipOrientation.vertically);

                    UpDateBoard(player);
                }

                i++;
            }
        }

        public void RegisterPlayer(Player player)
        {
            Players.Add(player);
        }

        public void UpDateBoard(Player player)
        {
            int i = 1;
            foreach(FieldsStatus boardField in player.Board.Fields)
            {
                char markToDisplay = (char)boardField;
                if (i % 10 == 0 ) { Console.WriteLine(markToDisplay + "   |   "); }
                else { Console.Write(markToDisplay + "   |   "); }
                i++;
            }
        }

    }
}
