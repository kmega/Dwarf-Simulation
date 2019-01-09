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
            if (runway != null)
            {
                if (runway.Status == RunwayStatus.Full)
                {
                    return LandingStatus.Failure;
                }

                this.Location = PlaneLocation.OnRunway;
                this.turnsOnRunway += 1;
                runway.Status = RunwayStatus.Full;
                return LandingStatus.Success;
            }

            return LandingStatus.Failure;
        }

        public void OnTurnTick()
        {
            this.turnsOnRunway += 1;
            if (turnsOnRunway >= 10)
            {
                this.Damage = PlaneDamage.None;
                this.turnsOnRunway = 0;
            }
            if (this.Location == PlaneLocation.InAir)
            {
                this.Fuel--;
            }
            else
            {
                if (this.Fuel < this.MaxFuel)
                {
                    this.Fuel = this.Fuel + 3;
                    if (this.Fuel == this.MaxFuel)
                    {
                        this.Fuel = this.MaxFuel;
                    }
                }
            }

        }

        #endregion IMPLEMENT ME

    }

}
