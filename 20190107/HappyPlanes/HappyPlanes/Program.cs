using System;

namespace HappyPlanes
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulate = new Simulation();

            simulate.Start(50, 5);

            Console.ReadKey();

        }
    }
}
