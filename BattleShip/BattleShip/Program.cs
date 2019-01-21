using System;
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
            Simulator simulator = new Simulator();

            simulator.Simulate();

            Console.ReadKey();
        }
    }
}
