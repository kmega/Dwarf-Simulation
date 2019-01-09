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
            foreach(Runway runway in runways)
            {
                if (runway.Status == RunwayStatus.Empty)
                    return runway;
            }

            return null;
        }

        public void Scrumble(PassingTime time, ControlTower tower)
        {
            
            var planesInHunger = new List<Plane>();
            int thisTurn = planesInHunger.Count();

            List<Plane> planes = new List<Plane>();

            foreach (Plane plane in planes)
            {
                if (plane.Location == PlaneLocation.Hangar)
                {
                    plane.Location = PlaneLocation.OnRunway;
                    planesInHunger.Add(plane);
                }
            }
            if (planesInHunger.Count>0)
            {
                time.AddTurn();
                Scrumble(time, tower);
            }
            planesInHunger[0].Location = PlaneLocation.InAir;

        }

        #endregion IMPLEMENT THIS CODE
    }
}
