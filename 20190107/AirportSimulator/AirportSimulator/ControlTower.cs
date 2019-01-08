using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator
{
    public class ControlTower
    {
        public List<Runway> landingzones = new List<Runway>();
       

       public int SearchFreeRunaway()
        {
            int answernumberrunaway = 0;

            foreach (var item in landingzones)
            {
                if (item.IsEnable == true)
                {
                    answernumberrunaway = item.number;
                    break;
                }
            }
            return answernumberrunaway;
        }


        public void RunwayCleaner()
        {
            foreach (var item in landingzones)
            {
                if (item.IsEnable == false)
                {
                    item.BlockedTimer -= 1;
                    if (item.BlockedTimer <= 0)
                    {
                        item.BlockedTimer = 5;
                        item.IsEnable = true;
                    }
                }

            }

        }
    }
}
