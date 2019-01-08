using System;

namespace HappyPlanes
{
    //ZUZYCIE  0.1 0.2 0.5
    public class AirPlane
    {
        public string Name { get; set; }
        public int Fuel { get; set; }
        public LandBelts LandBelt { get; set; }
        public bool OnTheAir { get; set; }
        public int MaxFuel { get; private set; }
        public AirPlane(string name,int Fuel)
        {
            OnTheAir = true;
            Name = name;
            this.Fuel = Fuel;
            MaxFuel = Fuel;
        }
     
        public  void SubstractFuel()
        {
            Fuel--;
        }
        public void RefuelPlain()
        {
            Fuel++;
            if(Fuel == MaxFuel)
            {
                OnTheAir = true;
            }
        }
    }
}