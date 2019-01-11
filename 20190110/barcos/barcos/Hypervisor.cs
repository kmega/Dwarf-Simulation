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


        public void InitiatePlayers(string player_1, string player_2)
        {
            string[] players = new string[2] { player_1, player_2 };
            int i = 0;

            foreach(Player player in Players)
            {
                player.Name = players[i];
                i++;
            }
            
        }

        public void RegisterPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
