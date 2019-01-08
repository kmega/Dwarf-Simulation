using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
{
    public class Airplane
    {
        public int fuel = 200;
        public bool inAir = true;
        public bool permission = false;
        private static int id = 0;
        public Airplane()
        {
            id++;
        }

        public void RequestForPermission(ControlTower controlTower)
        {
            if (controlTower.isAnyFreeAirstrip())
                permission = true;
            else
            {
                permission = false;
                fuel--;
            }   
        }
        public void TryLand(Airstrip airstrip)
        {
            airstrip.isFree = false;
            this.inAir = false;
            Console.Write("WYLADOWAL");
        }
    }
}
