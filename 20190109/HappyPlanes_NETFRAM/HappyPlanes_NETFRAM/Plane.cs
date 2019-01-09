using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public class Plane
    {
        #region DO NOT CHANGE THIS CODE

        int turnsOnRunway = 0;
        int turnsToLeaveHangar = 3;
        public bool IsHangarLeavingEngaged = false;

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

        internal void OnLeaveTick(Runway runway)
        {
            turnsToLeaveHangar -= 1;
            if(turnsToLeaveHangar == 0)
            {
                Location = PlaneLocation.OnRunway;
                runway.Status = RunwayStatus.Full;
                runway.landedPlane = this;
            }
        }

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

        public void OnTurnTick(Runway runway)
        {
            if (Location == PlaneLocation.OnRunway)
            {
                Refuel();
                CheckIfPlanesHeales();
                CheckIfPlanesGoesToHangar(runway);
            }
            if(Location == PlaneLocation.InAir)
            {
                Fuel -= 1;
            }          
        }
        private void Refuel()
        {
            Fuel += 3;
            if (Fuel > MaxFuel)
            {
                Fuel = MaxFuel;
            }
        }
        private void CheckIfPlanesHeales()
        {
            turnsOnRunway += 1;
            if (turnsOnRunway >= 10 && Damage == PlaneDamage.Damaged)
            {
                Damage = PlaneDamage.None;
            }
        }
        public void CheckIfPlanesGoesToHangar(Runway runway)
        {
            if (turnsOnRunway >= 25)
            {
                Location = PlaneLocation.InHangar;
                turnsToLeaveHangar = 3;
                runway.Status = RunwayStatus.Empty;
            }
        }

        public void LeaveHangar()
        {
            IsHangarLeavingEngaged = true;
        }

        #endregion IMPLEMENT ME

    }

}
