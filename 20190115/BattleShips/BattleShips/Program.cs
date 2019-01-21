using BattleShips.Models;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>()
            {
                new Player(),
                new Player()
            };
            UI ui = new UI();
        }
    }
}
