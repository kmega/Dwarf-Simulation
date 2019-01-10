using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    public class ListPlanes
    {
        public List<Plane> planelist = new List<Plane>();
        private int[] fuelarray = new int[] { 1, 3, 5, 7, 9 };

        public void AddPlane(int iterator)
        {
            planelist.Add(new Plane (fuelarray[iterator]));
        }

        public void DecreaseFuel()
        {
            for (int j = 0; j < planelist.Count; j++)
            {
                if (planelist[j].landed == false)
                {
                    planelist[j].FuelLeft -= 1;
                }
            }
        }

        public void CheckFuel(){

            for (int j = 0; j < planelist.Count; j++)
            {
                if (planelist[j].FuelLeft == 0)
                {
                    planelist[j].isCrashed = true;
                }
            }
        }

        public void CheckLowestFuel()
        {
            planelist = planelist.OrderBy(x => x.FuelLeft).ToList();
        }
    }
}
