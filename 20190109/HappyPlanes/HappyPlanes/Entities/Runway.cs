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
            //throw new NotImplementedException();
            if (plane.Location == PlaneLocation.InAir)
            {
                plane.TryLandOn(this);
                landedPlane = plane;

            }
        }

        public Plane LaunchPlane()
        {
            if (landedPlane.Fuel >= landedPlane.MaxFuel / 2 &&
                landedPlane.Fuel <= landedPlane.MaxFuel)
            {
                status = RunwayStatus.Empty;
                return landedPlane;
            }

            else
            {
                return null;
            }

            //throw new NotImplementedException();
        }

        #endregion IMPLEMENT THIS CODE
    }

}
