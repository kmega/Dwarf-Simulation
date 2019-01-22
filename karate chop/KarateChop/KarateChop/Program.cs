using System;

namespace KarateChop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create chopper
            Chopper chopper = new Chopper();
            int[] arrToPass = { 1, 2, 3 };

            //Pass array to its method
            Console.WriteLine(chopper.ChopInHalf(2,arrToPass));
            Console.ReadKey();
            
        }
    }
}
