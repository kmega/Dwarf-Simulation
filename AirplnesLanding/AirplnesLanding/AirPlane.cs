using System;

namespace HappyPlanes
{
    public class AirPlane
    {
        public enum Names
        {
            
        }

        public string Name { get; set; }
        public int Fuel { get; set; }
        public LandBelts LandBelt { get; set; }
        public bool LandingSucces { get; set; }
        public bool PermissionToLanding { get; set; }
        public bool OnTheAir { get; set; }


        public AirPlane(string name)
        {
            OnTheAir = true;
            PermissionToLanding = false;
            Name = name;
            Fuel = 200;
        }

        public void PermissionLandingAsk(string name)
        {
            Console.WriteLine($"Tutaj {name} Czy mogę podejść do lądowania?");
        }
    }
}