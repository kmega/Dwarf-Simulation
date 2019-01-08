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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    listofplanes.AddPlane(j);
                    if (turn > 3)
                    {
                        ct.PlaneLand(listofplanes.planelist);
                    }
                    listofplanes.DecreaseFuel();
                    listofplanes.CheckFuel();
                    listofplanes.CheckLowestFuel();
                    ct.TrackOccupied();
                    turn++;



                }
            }

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
