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
            if (runway == null || runway.Status == RunwayStatus.Full)
            {
                return LandingStatus.Failure;
            }
            else
            {
                runway.AcceptPlane(this);
                Location = PlaneLocation.OnRunway;
                return LandingStatus.Success;
            }
        }

        public void OnTurnTick()
        {
            turnsOnRunway++;
            if (Location == PlaneLocation.InAir || Location == PlaneLocation.Unknown)
            {
                Fuel--;
            }
            else turnsOnRunway++;
            if (Location == PlaneLocation.OnRunway)
                if (Fuel != MaxFuel)
                {
                    Fuel += 3;
                }
                else if (Fuel > MaxFuel)
                {
                    Fuel = MaxFuel;
                }
            if (Damage == PlaneDamage.Damaged)
            {
                if (turnsOnRunway > 9)
                {
                    Damage = PlaneDamage.None;
                }
            }
        }

        #endregion IMPLEMENT ME

    }

}
