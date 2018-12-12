using System.Collections.Generic;
using System.Diagnostics;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Robot> robots = new List<Robot>()
            {
                new Robot(){Attack = 14, Defense = 5, HP = 100},
                new Robot(){Attack = 6, Defense = 11, HP = 100}
            };
            Arena arena = new Arena();
            arena.Fight(robots);
        }
    }
}
