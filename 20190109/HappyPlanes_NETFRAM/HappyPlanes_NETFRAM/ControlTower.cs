using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes.Entities
{
    public class ControlTower
    {
        #region DO NOT TOUCH THIS CODE

        private Runway[] runways;

        public ControlTower(Runway[] runways)
        {
            this.runways = runways;
        }

        #endregion DO NOT TOUCH THIS CODE

        #region IMPLEMENT THIS CODE

        public Runway GetAvailableRunway()
        {
            var avilableRunways = runways.Where(x => x.Status == RunwayStatus.Empty);
            return avilableRunways.FirstOrDefault();
        }
       /* public void CheckPlanesInHangar (PassingTime passingTime)
        {
            foreach (var plane in passingTime.planes)
            {
                if (plane.turnsOnRunway > 28 && plane.Location == PlaneLocation.InHangar)
                {
                    GetAvailableRunway().AcceptPlane(plane);
                }
            }
        }*/
        #endregion IMPLEMENT THIS CODE
    }
}
