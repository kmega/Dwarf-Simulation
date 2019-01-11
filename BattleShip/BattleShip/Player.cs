﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {
       public Board Player_Board { get; set; }
       public int Id { get; set; }
       public Board Opponent_Board { get; set; }
       public List<Ship> ships { get; set; }

        public Player(int Id)
        {
            this.Id = Id;

            ships = new List<Ship>()
            {
                new Ship(1,1),
                new Ship(2,2),
                new Ship(3,3),

            };

            Player_Board = new Board();
            Opponent_Board = new Board();
        }

        public void ShowShips(Player player)
        {
            foreach (var ship in player.ships)
            {

                Console.WriteLine("Ship id " + ship.Id.ToString() + " Lenght Ship " + ship.Lenght);
            }
        }

        public void ShowBoard(Player player)
        {
            Console.Write("\t" );
            for (int i = 1; i < 11; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0,k = 1; i < player.Player_Board.Fields.GetLength(0); i++)
            {
               
                    Console.Write(k++ + "\t" );
                
                    
                 
                for (int j = 0; j < player.Player_Board.Fields.GetLength(1); j++)
                {
                    
                    Console.Write(player.Player_Board.Fields[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}