using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public class Runway
    {
        #region DO NOT TOUCH THIS CODE

        private string name;
        private RunwayStatus status;
        private Plane landedPlane;

        public Runway(string name, RunwayStatus status = RunwayStatus.Empty)
        {
            this.name = name;
            this.status = status;
            this.landedPlane = null;
        }

        public RunwayStatus Status { get => status; set => status = value; }
        public string Name { get => name; }

        #endregion DO NOT TOUCH THIS CODE

        #region IMPLEMENT THIS CODE

        public void AcceptPlane(Plane plane)
        {
            Plane tempPlane = plane;

            if(tempPlane.Location == PlaneLocation.InAir 
                && Status == RunwayStatus.Empty)
            {
                landedPlane = plane;
                landedPlane.TryLandOn(this);
                Status = RunwayStatus.Full;
            }
            //throw new NotImplementedException();
        }

        public Plane LaunchPlane()
        {
            if(landedPlane.Fuel == landedPlane.MaxFuel && landedPlane.Damage != PlaneDamage.Damaged)
            {
                status = RunwayStatus.Empty;
                return landedPlane;
            }
            else if(landedPlane.Damage == PlaneDamage.Damaged)
            {
                return null;
            }
            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }

}
