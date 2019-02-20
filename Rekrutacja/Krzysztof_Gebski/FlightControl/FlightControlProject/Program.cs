using System;

namespace FlightControlProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game.StartGame(20);

            Console.WriteLine($"Number of airplanes lands: {Stats.AirplanesLand}");

            Console.WriteLine($"Number of destroyed airplanes: {Stats.AirplanesDestroyed}");

            Console.ReadKey();
        }
    }
}