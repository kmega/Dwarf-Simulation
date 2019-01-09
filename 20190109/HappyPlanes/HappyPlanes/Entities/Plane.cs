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

            if (runway == null)
            {
                Location = PlaneLocation.InAir;
                return LandingStatus.Failure;
            }

            else if (runway.Status == RunwayStatus.Full && Location == PlaneLocation.InAir)
            {
                Location = PlaneLocation.InAir;

                return LandingStatus.Failure;
            }

            else if (runway.Status == RunwayStatus.Empty && Location == PlaneLocation.InAir)
            {

                Location = PlaneLocation.OnRunway;
                runway.Status = RunwayStatus.Full;

                return LandingStatus.Success;
            }

            else return LandingStatus.Unknown;
        }

        public void OnTurnTick()
        {
            if (Location == PlaneLocation.InAir)
                Fuel--;

            else if (Location == PlaneLocation.OnRunway)
            {
                Fuel += 3;
                turnsOnRunway++;
            }

            if(turnsOnRunway >= 10)
            {
                Damage = PlaneDamage.None;
            }

            if (turnsOnRunway == 25)
            {
                Location = PlaneLocation.Hangar;

            }

            if (Fuel > MaxFuel)
                Fuel = MaxFuel;
        }

        #endregion IMPLEMENT ME

    }

}
