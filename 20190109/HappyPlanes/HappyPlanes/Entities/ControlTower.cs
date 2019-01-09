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

            foreach (Runway lane in runways)
            {
                if (lane.Status == RunwayStatus.Empty)
                {
                    //it tricked me at 8th test
                    //lane.Status = RunwayStatus.Full;
                    return lane;
                }
            }

            //var temp = runways.Where(x => x.Status == RunwayStatus.Empty);

            //if(temp.Count() == runways.Count())
            //{

            //}

            return null;

            //var tempRunaway = runways.First();

            //if(tempRunaway.Status == RunwayStatus.Empty)
            //{
            //    return tempRunaway;
            //}
            //return null;
        }

        #endregion IMPLEMENT THIS CODE
    }
}
