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
            //metoda Status ma zwrócić RunwayStatus.Full 
            //if (location: PlaneLocation.InAir)
            if (plane.Location == PlaneLocation.InAir)            
                this.Status = RunwayStatus.Full;
            //jeżeli PlaneLocation.OnRunway); -> RunwayStatus.Empty
            else
                this.Status = RunwayStatus.Empty;
 
        }

        public Plane LaunchPlane()
        {
            throw new NotImplementedException();

        }

        #endregion IMPLEMENT THIS CODE
    }

}
