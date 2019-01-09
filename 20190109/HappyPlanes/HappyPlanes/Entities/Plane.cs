using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public class Plane
    {
        #region DO NOT CHANGE THIS CODE

        public int turnsOnRunwayOrHangar = 0;
        public int waitinQuene = 0;

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
        public PlaneLocation Location { get;  set; }
        public int MaxFuel { get; private set; }
        public PlaneDamage Damage { get; private set; }
        public int Fuel { get; set; }

        #endregion DO NOT CHANGE THIS CODE

        #region IMPLEMENT ME

        public LandingStatus TryLandOn(Runway runway)
        {
           if (runway==null || runway.Status == RunwayStatus.Full)
            {
                return LandingStatus.Failure;
            }
           else
            {
                runway.AcceptPlane(this);
                
                return LandingStatus.Success;
                

            }
        }

      

        public void OnTurnTick()
        {

            if (Location==PlaneLocation.InAir||Location==PlaneLocation.Unknown)
            {
                Fuel--;
            }
            else
            {

                turnsOnRunwayOrHangar++;
                if (!(Fuel == MaxFuel))
                {
                    Fuel += 3;
                }
                if (Fuel > MaxFuel)
                {
                    Fuel = MaxFuel;
                    
                }
                if (Damage == PlaneDamage.Damaged)
                {
                    if (turnsOnRunwayOrHangar >= 10)
                    {
                        Damage = PlaneDamage.None;
                    }
                }
               



            }
            

        }

        #endregion IMPLEMENT ME

    }

}
