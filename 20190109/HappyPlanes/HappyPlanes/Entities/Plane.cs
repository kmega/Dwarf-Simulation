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
        public PlaneLocation Location { get; set; }
        public int MaxFuel { get; private set; }
        public PlaneDamage Damage { get; private set; }
        public int Fuel { get; set; }

        #endregion DO NOT CHANGE THIS CODE

        #region IMPLEMENT ME


        public LandingStatus TryLandOn(Runway runway)
        {

            if (runway == null && Location == PlaneLocation.InAir)
            {
                return LandingStatus.Failure;
            }
            if (Location == PlaneLocation.InAir && runway.Status == RunwayStatus.Full)
            {
                return LandingStatus.Failure;
            }
            if (Location == PlaneLocation.OnRunway && runway.Status == RunwayStatus.Full)
            {
                return LandingStatus.Success;
            }
            if (Location == PlaneLocation.InAir && runway.Status == RunwayStatus.Empty)
            {
                runway.AcceptPlane(this);
                Location = PlaneLocation.OnRunway;
                runway.Status = RunwayStatus.Full;
                return LandingStatus.Success;
            }
            return LandingStatus.Unknown;
        }

        public void OnTurnTick()
        {
            if (Location == PlaneLocation.InAir)
            {
                Fuel = Fuel - 1;
            }
            if (Location == PlaneLocation.OnRunway)
            {
                turnsOnRunway++;
                if (turnsOnRunway == 10)
                {
                    Damage = PlaneDamage.None;
                }
                Fuel += 3;
                if (Fuel > MaxFuel)
                {
                    Fuel = MaxFuel;
                }
            }
        }

        #endregion IMPLEMENT ME

    }

}
