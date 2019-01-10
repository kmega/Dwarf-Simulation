using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    public class Task
    {
        ControlTower ct = new ControlTower();
        ListPlanes listofplanes = new ListPlanes();

        public void DoTask()
        {
            int turn = 1;
            int iterator = 0;
            do
            {
                if (listofplanes.planelist.Count < 50)
                {
                    listofplanes.AddPlane(iterator);
                }
                if (turn > 3)
                {
                    ct.PlaneLand(listofplanes.planelist);
                }
                listofplanes.DecreaseFuel();
                listofplanes.CheckFuel();
                listofplanes.CheckLowestFuel();
                ct.TrackOccupied();
                turn++;
                iterator++;
                if (iterator == 5)
                {
                    iterator = 0;
                }
            } while ((listofplanes.planelist.Exists(x => x.isCrashed == false
                && x.landed == false)) || listofplanes.planelist.Count < 50);

            int countCrashedPlanes = listofplanes.planelist.FindAll(x => x.isCrashed == true).Count();
            int countLandedPlanes = listofplanes.planelist.FindAll(x => x.landed == true).Count();

            Console.WriteLine($"Wylądowało: {countLandedPlanes} \nRozbiło się: {countCrashedPlanes}\n" +
                $"Zajęło to {turn} tur");
        }
    }
}
