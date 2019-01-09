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
            if (plane.Location == PlaneLocation.InAir && this.Status == RunwayStatus.Empty)
            {
                this.status = RunwayStatus.Full;
                this.landedPlane = plane;
            }
            else { this.status = RunwayStatus.Empty; }
        }

        public Plane LaunchPlane()
        {
            if (this.status == RunwayStatus.Full)
            {
                if (this.landedPlane != null)
                {
                    if (this.landedPlane.Damage != PlaneDamage.Damaged)
                    {
                        if (this.landedPlane.MaxFuel / 2 < this.landedPlane.Fuel)
                        {
                            this.status = RunwayStatus.Empty;
                            return this.landedPlane;
                        }
                    }

                }
            }
            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }

}
