using System;

namespace HappyPlanes
{
    public class AirPlane
    {
        public string Name { get; set; }
        public int Fuel { get; set; }
        public LandBelts LandBelt { get; set; }
        public bool LandingSucces { get; set; }
        public bool PermissionToLanding { get; set; }


        public AirPlane(string name)
        {
            PermissionToLanding = false;
            Name = name;
            Fuel = 200;
        }

        public void PermissionLandingAsk()
        {
            Console.WriteLine("Czy mogę podejść do lądowania?");
        }
    }
}