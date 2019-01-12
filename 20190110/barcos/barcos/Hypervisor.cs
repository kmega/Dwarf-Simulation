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

                foreach (var ship in player.Ships)
                {
                    Console.WriteLine(player.Name + " - set ship " + ship.Masts + " coordinate X: ");

                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(player.Name + " - set ship " + ship.Masts + " coordinate Y: ");
                    int y = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(player.Name + " is your ship " + ship.Masts + " orientation horizontal?");
                    bool orientation = Convert.ToBoolean(Console.ReadLine());

                    if (orientation) { player.SetShipsOnBoard(ship, x, y, ShipOrientation.horizontally); }
                    else { player.SetShipsOnBoard(ship, x, y, ShipOrientation.vertically); }
                }

                i++;
            }
        }

        public void RegisterPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
