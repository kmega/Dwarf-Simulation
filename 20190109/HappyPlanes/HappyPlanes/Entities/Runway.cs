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
        public static List<Plane> Hangar { get; set; } = new List<Plane>();

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
            if(plane.Location == PlaneLocation.InAir && status == RunwayStatus.Empty)
            {
                plane.TryLandOn(this);
                status = RunwayStatus.Full;
                landedPlane = plane;
            }
            
        }

        public static void GoToHangar(Plane plane)
        {
            Hangar.Add(plane);
        }

        public Plane LaunchPlane()
        {
            if(landedPlane.Damage == PlaneDamage.Damaged)
            {
                return null;
            }
            if(landedPlane.Fuel > (landedPlane.MaxFuel/2))
            {
                status = RunwayStatus.Empty;
                return landedPlane;
            }
            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }

}
