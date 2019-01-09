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
            //throw new NotImplementedException();
            if (runway == null)
            {
                return LandingStatus.Failure;
            }

            else
            {
                switch (runway.Status)
                {
                    case RunwayStatus.Full:
                        return LandingStatus.Failure;
                    case RunwayStatus.Empty:
                        this.Location = PlaneLocation.OnRunway;
                        runway.Status = RunwayStatus.Full;
                        return LandingStatus.Success;
                    default:
                        return LandingStatus.Unknown;
                }
            }
        }

        public void OnTurnTick()
        {
            //throw new NotImplementedException();
            switch (this.Location)
            {
                case PlaneLocation.InAir:
                    Fuel--;
                    break;
                case PlaneLocation.OnRunway:
                    Fuel += 3;
                    break;
            }

        }

        #endregion IMPLEMENT ME

    }

}
