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
            if (runway == null ||runway.Status == RunwayStatus.Full )
            {
                return LandingStatus.Failure;
            }
            else
            {
                runway.AcceptPlane(this);
                this.Location = PlaneLocation.OnRunway;
                return LandingStatus.Success;
            }
        }

        public void OnTurnTick()
        {
            if (this.Damage == PlaneDamage.Damaged)
            {
                turnsOnRunway += 1;
                if(turnsOnRunway >= 10)
                {
                    Damage = PlaneDamage.None;
                }
            }
            if (Location == PlaneLocation.OnRunway)
            {
                this.Fuel += 3;
                turnsOnRunway += 1;
                if (Fuel > MaxFuel)
                {
                    Fuel = MaxFuel;
                }
            }
            else
            {
                this.Fuel -= 1;
            }
            
        }

        #endregion IMPLEMENT ME

    }

}
