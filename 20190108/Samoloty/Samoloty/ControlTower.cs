using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
{
    public class ControlTower
    {
        List<Airstrip> airstrips = new List<Airstrip>();
        private Airstrip readyForAction;
        public ControlTower(List<Airstrip> airstrips)
        {
            this.airstrips = airstrips;
        }
        public bool isAnyFreeAirstrip()
        {
            foreach (Airstrip airstrip in airstrips)
                if (airstrip.isFree)
                {
                    readyForAction = airstrip;
                    return true;
                }
            return false;
        }
        public Airstrip GetFreeAirstrip()
        {
            return readyForAction;
        }
        public void RestoreAirstrip()
        {
            foreach (Airstrip airstrip in airstrips)
                if (airstrip.isFree == false)
                {
                    airstrip.isFree = true;
                    break;
                }
        }

    }
}
