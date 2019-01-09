using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public class Plane
    {
        #region DO NOT CHANGE THIS CODE

        int turnsOnRunway = 0;

        public Plane(string name, PlaneLocation location, int fuel, 
            PassingTime passingTime, int maxFuel, PlaneDamage damage)
        {
            this.Name = name;
            Location = location;
            this.Fuel = fuel;
            this.MaxFuel = maxFuel;
            this.Damage = damage;
            passingTime.RegisterPlane(this);
        }

        public string Name { get; private set; }
        public PlaneLocation Location { get; private set; }
        public int MaxFuel { get; private set; }
        public PlaneDamage Damage { get; private set; }
        public int Fuel { get; set; }

        #endregion DO NOT CHANGE THIS CODE

        #region IMPLEMENT ME

        public LandingStatus TryLandOn(Runway runway)
        {

            if (runway == null)
            {
                this.Location = PlaneLocation.InAir;
                return LandingStatus.Failure;
            }

            if (runway.Status == RunwayStatus.Full)
            {
                this.Location = PlaneLocation.InAir;
                runway.Status = RunwayStatus.Full;

                return LandingStatus.Failure;
            }
            else if (runway.Status == RunwayStatus.Empty)
            {
                this.Location = PlaneLocation.OnRunway;
                runway.Status = RunwayStatus.Full;
                return LandingStatus.Success;
            }
            else
            {
                 throw new NotImplementedException();
            }
        }

        public void OnTurnTick()
        {
        
           
            if (Location == PlaneLocation.InAir) //jak samolot jest w powietrzu -1 paliwa
            {
                this.Fuel = this.Fuel - 1;
            }
            if ( this.Fuel == MaxFuel & Location == PlaneLocation.OnRunway)
            {
                this.Fuel = this.Fuel;                
            }
            else if (this.Fuel < MaxFuel & Location == PlaneLocation.OnRunway) // samolot na pasie +3 paliwa
            {
                
                this.Fuel = this.Fuel + 3;
            }
            
            //else if(Name == "runway 01")
            //{
            //    //addturn to jeden fuelBURN!!!!!
            //    MaxFuel = 100;
            //    this.Fuel = 100- 4*1 + 1*3
            //    int fuelBurn = 1;
            //    int fuelGain = 3;
            //    plane.Fuel == initialFuel - 4 * fuelBurn + 1 * fuelGain)
            //}

            //if (runway.Status == RunwayStatus.Empty)
            //throw new NotImplementedException();
        }

        #endregion IMPLEMENT ME

    }

}
