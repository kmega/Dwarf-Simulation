using System;
using System.Collections.Generic;
using barcos.Enums;

namespace barcos
{
    public class Hypervisor
    {
        public int TurnCounter; // ??????
        public GameState GameState;

        public Hypervisor()
        {
            //phase 1
            InitiatePlayers();
 
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


        private void InitiatePlayers()
        {

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("What is Your name, Player{0}?", i);
                players[i].Name = Console.ReadLine();

                Console.WriteLine("Hello in BattleShip game, {0}!", players[i].Name);
            }
        }
    }
}
