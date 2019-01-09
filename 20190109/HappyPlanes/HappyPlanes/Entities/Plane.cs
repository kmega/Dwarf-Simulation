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
            // korzystajac z runway status 
            //return LandingStatus.Failure,  Assert.IsTrue(result == LandingStatus.Failure);
            //Assert.IsTrue(plane.Location == PlaneLocation.InAir);
            //Assert.IsTrue(runway.Status == RunwayStatus.Full);

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
            //Assert.IsTrue(result == LandingStatus.Success);
            //Assert.IsTrue(plane.Location == PlaneLocation.OnRunway);
            //Assert.IsTrue(runway.Status == RunwayStatus.Full);
            //jeżeli planelocation in air i runway status = null
            //Assert.IsTrue(runway == null);
            //Assert.IsTrue(result == );
            //Assert.IsTrue(plane.Location == );

        }

        public void OnTurnTick()
        {
            if (Location == PlaneLocation.InAir)
            {
                MaxFuel = 100;
                this.Fuel = MaxFuel - 1;
            }
            // without else if below, 11 and 12 works
            else if (Location == PlaneLocation.OnRunway)
            {
                MaxFuel = 100;
                this.Fuel = MaxFuel + 3;
            }

            //if (runway.Status == RunwayStatus.Empty)
            //throw new NotImplementedException();
        }

        #endregion IMPLEMENT ME

    }

}
