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
            for (int i = 0; i < runways.Length; i++)
            {
                if (runways[i].Status == RunwayStatus.Empty)
                {
                    runways[i].Status = RunwayStatus.Full;
                    return runways[i];
                }
            }
            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }
}
