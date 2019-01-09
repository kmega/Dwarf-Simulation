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
                if (iterator==5)
                {
                    iterator = 0;
                }

                    
                
            } while ((listofplanes.planelist.Exists(x => x.isCrashed == false && x.landed == false))
            || listofplanes.planelist.Count<50);

            int landed = 0;
            int crashed = 0;

            foreach (var elem in listofplanes.planelist)

            {
                if (elem.isCrashed)
                {
                    crashed++;
                }
                if (elem.landed)
                {
                    landed++;
                }
            }
            Console.WriteLine($"Wylądowało: {landed} \nRozbiło się: {crashed}\n" +
                $"Zajęło to {turn} tur");
        }
    }
}
