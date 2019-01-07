using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyPlanes
{
    class Program
    {
        static void Main(string[] args)
        {
            FlySymulator symulator = new FlySymulator();
            symulator.Run();
            Console.ReadKey();                      
        }
    }
}
