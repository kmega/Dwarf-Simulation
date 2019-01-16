using System;
using System.Collections.Generic;
using barcosFinal.Enums;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Podaj imię gracza 1");
            UI ui = new UI();
//            
//
            IPlayer player1 = new Player()
            {
                BattleField = new BattleField(),
                Ships = new List<IShip>()
                {
                    new Ship(2, 1, 2, Orientation.vertical)
                }
            };


            IPlayer player2 = new Player()
            {
                BattleField = new BattleField(),
                Ships = new List<IShip>()
                {
                    new Ship(2, 1, 2, Orientation.vertical)
                }
            };


            Console.ReadLine();
        }
    }
}