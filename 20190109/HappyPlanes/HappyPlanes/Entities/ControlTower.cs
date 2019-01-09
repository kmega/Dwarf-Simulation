
using System;

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
            // Runway Status - jak się odwołać

            //metoda ma zwrócić :
            //Assert.IsTrue(result != null);
            //Assert.IsTrue(result.Name == runway.Name);
            //this.runways = "runway 01";
            for (int i = 0; i < runways.Length; i++)
            {
               
                if (this.runways[i].Status == RunwayStatus.Empty)
                {                    
                    return runways[i];
                }
            }

            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }
}
