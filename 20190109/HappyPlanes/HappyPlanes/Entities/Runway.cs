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
            if (plane.Location == PlaneLocation.InAir && status == RunwayStatus.Empty)
            {
                status = RunwayStatus.Full;
                landedPlane = plane;
                plane.Location = PlaneLocation.OnRunway;
            }
            if (plane.Location == PlaneLocation.OnRunway && status == RunwayStatus.Empty)
            {
                status = RunwayStatus.Empty;
            }
        }

        public Plane LaunchPlane()
        {
            if (landedPlane.Fuel > landedPlane.MaxFuel /2 && landedPlane.Damage == PlaneDamage.None)
            {
                status = RunwayStatus.Empty;
                return landedPlane;
            }
            if (landedPlane.Damage == PlaneDamage.Damaged)
            {

            }
            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }

}
