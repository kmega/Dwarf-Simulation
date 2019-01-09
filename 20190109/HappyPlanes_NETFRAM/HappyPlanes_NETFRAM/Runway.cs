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
            if(status == RunwayStatus.Empty && plane.Location == PlaneLocation.InAir)
            {
                plane.Location = PlaneLocation.OnRunway;
                status = RunwayStatus.Full;
                landedPlane = plane;             
            }
            
        }

        public Plane LaunchPlane()
        {
            if (landedPlane.Fuel > landedPlane.MaxFuel /2 && landedPlane.Damage != PlaneDamage.Damaged)
            {
                Status = RunwayStatus.Empty;
                return landedPlane;
            }
            else
            {
                return null;
            }
        }

        #endregion IMPLEMENT THIS CODE
    }

}
