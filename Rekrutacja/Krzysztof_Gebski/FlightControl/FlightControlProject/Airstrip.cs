using System.Collections.Generic;

namespace FlightControlProject
{
    public class Airstrip
    {
        public Airstrip()
        {
            IsFree = true;
        }

        public bool IsFree { get; set; }

        public static List<Airstrip> CreateAirstrips(int number)
        {
            List<Airstrip> airstrips = new List<Airstrip>();
            for (int i = 0; i < number; i++)
            {
                airstrips.Add(new Airstrip());
            }
            return airstrips;
        }
    }
}