﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(1);
            PreperePlayer prepere = new PreperePlayer();
            prepere.ShowShips(player1);

           
            prepere.ShowBoard(player1);
           

            Console.ReadKey();


        }
    }
}
