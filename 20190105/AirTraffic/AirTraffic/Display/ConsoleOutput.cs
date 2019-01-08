using System;

namespace AirTraffic
{
    internal class ConsoleOutput
    {
        public void DisplayLandingPlane(int laneAmount, LaneCreator lane, PlaneCreator plane)
        {
            Console.WriteLine("Amount of free lanes: {0}", laneAmount);
            Console.WriteLine("Here plane with id: {0}. Can we land?", plane.number);

            if (laneAmount == 0)
            {
                Console.WriteLine("All lanes taken, stay in air");
                Console.WriteLine("Fuel left: {0}", plane.ActualFuel);
            }
            else
            {
                Console.WriteLine("Landing allowed on {0} lane", lane.encryptedLaneName);
                Console.WriteLine("Landed with: {0} fuel left", plane.ActualFuel);
                Console.WriteLine("Amount of free lanes: {0}", laneAmount-1);
            }
            Console.WriteLine();
        }
    }
}