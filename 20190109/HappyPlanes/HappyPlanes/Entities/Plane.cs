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
                Location = PlaneLocation.InAir;
                return LandingStatus.Failure;
            }
            if (runway.Status == RunwayStatus.Full)
            {
                runway.Status = RunwayStatus.Full;
                return LandingStatus.Failure;
            }
            else if(runway.Status == RunwayStatus.Empty)
            {

                runway.Status = RunwayStatus.Full;
                Location = PlaneLocation.OnRunway;
                
                return LandingStatus.Success;

            }
            
            return LandingStatus.Unknown;
        }

        public void OnTurnTick()
        {
            turnsOnRunway++;

            if(turnsOnRunway%3 == 0)
            {

            }

            if(turnsOnRunway == 10 && Damage == PlaneDamage.Damaged)
            {
                Damage = PlaneDamage.None;
            }

            if(turnsOnRunway >= 25)
            {                
                Location = PlaneLocation.Hangar;
                Runway.GoToHangar(this);
                
            }

            if (Location == PlaneLocation.InAir)
            {
                Fuel--;
            }
            else if (Location == PlaneLocation.OnRunway)
            {

                if (Fuel == MaxFuel) return;
                Fuel += 3;               
            }
            
        }

        #endregion IMPLEMENT ME

    }

}
