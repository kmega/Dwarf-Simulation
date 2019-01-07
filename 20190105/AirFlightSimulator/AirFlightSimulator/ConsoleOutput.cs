using System;

namespace AirFlightSimulator
{
    class ConsoleOutput
    {
        public void DisplayStatus(Planes plane, LandingLane singleLaneFromCollection)
        {
            Console.WriteLine("Samolot {0} laduje na pasie {1}", plane.planeNumber, singleLaneFromCollection.lanePositionEncrypted);
        }
    }
}