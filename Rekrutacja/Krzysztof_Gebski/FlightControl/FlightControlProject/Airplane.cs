using System.Collections.Generic;

namespace FlightControlProject
{
    public class Airplane
    {
        public Airplane(int maxFuel)
        {
            Fuel = maxFuel;
            MaxFuel = maxFuel;
            TimeOnGround = 0;
            IsInAir = true;
        }

        public int Fuel { get; set; }
        public bool IsInAir { get; set; }
        public int MaxFuel { get; set; }
        public int TimeOnGround { get; set; }

        public static List<Airplane> CreateAirplanes(int number, int maxFuel)
        {
            List<Airplane> airplanes = new List<Airplane>();
            for (int i = 0; i < number; i++)
            {
                airplanes.Add(new Airplane(maxFuel));
            }
            return airplanes;
        }
    }
}