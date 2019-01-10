using System;
using System.Collections.Generic;
using barcos.Enums;

namespace barcos
{
    public class Hypervisor
    {
        public int TurnCounter; // ??????
        public GameState GameState;

        public Hypervisor(List<Player> players)
        {
            //phase 1

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("What is Your name, Player{0}?",i);
                players[i].Name = Console.ReadLine();

                Console.WriteLine("Hello in BattleShip game, {0}!", players[i].Name);
            }
 
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
    }
}
