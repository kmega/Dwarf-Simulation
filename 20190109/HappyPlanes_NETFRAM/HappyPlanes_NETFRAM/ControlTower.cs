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

        public void Scrumble(PassingTime time)
        {
            time.IsScrumbleEngaged = true;
            ArrangeEmptyingHangars(time);
            
            while(time.scrumbleRunway.scrumblePlanes.Any())
            {
                var plane = time.scrumbleRunway.scrumblePlanes.Dequeue();
                plane.TakeOff(time.scrumbleRunway);
                time.AddTurn();
            }

        }
        private void ArrangeEmptyingHangars(PassingTime time)
        {
            foreach(var plane in time.planes)
            {
                plane.LeaveHangar();
            }
            for(int i =0; i<3; i++)
            {
                time.AddTurn();
            }
        }

        #endregion IMPLEMENT THIS CODE
    }
}
