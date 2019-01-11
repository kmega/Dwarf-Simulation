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
            //phase 1
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


        public void InitiatePlayers()
        {
            int i = 0;
            foreach(Player player in Players)
            {
                Console.WriteLine("What is Your name, Player{0}?", i);
                player.Name = Console.ReadLine();

                Console.WriteLine("Hello in BattleShip game, {0}!", player.Name);

                i++;
            }
            
        }

        public void RegisterPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
