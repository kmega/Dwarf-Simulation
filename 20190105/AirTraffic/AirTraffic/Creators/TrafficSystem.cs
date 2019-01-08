using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTraffic
{
    public class TrafficSystem
    {
        //private int planesAmount;
        //public int lanesAmount;
        //private int minmalFuel;
        //private int maximumFuel;

        //public TrafficSystem(int planesAmount, int lanesAmount, int minmalFuel, int maximumFuel)
        //{
        //    this.planesAmount = planesAmount;
        //    this.lanesAmount = lanesAmount;
        //    this.minmalFuel = minmalFuel;
        //    this.maximumFuel = maximumFuel;
        //}

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        public List<LaneCreator> lane = GenerateLanes(2);

        public List<PlaneCreator> Planes = GeneratePlanes(5);
        

        private static List<PlaneCreator> GeneratePlanes(int amount)
        {
            List<PlaneCreator> returnPlanes = new List<PlaneCreator>();

            for (int i = 0; i < amount; i++)
            {
                returnPlanes.Add(new PlaneCreator(RandomString(3), 200));
            }

            return returnPlanes;
        }

        private static List<LaneCreator> GenerateLanes(int amount)
        {
            List<LaneCreator> returnLanes = new List<LaneCreator>();

            for (int i = 0; i < amount; i++)
            {
                returnLanes.Add(new LaneCreator(RandomString(5), false, 0));
            }

            return returnLanes;
        }
    }
}
