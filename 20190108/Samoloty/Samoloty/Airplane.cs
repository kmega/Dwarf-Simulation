using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
{
    public class Airplane
    {
        public int PlaneFuel;
        public int TankCapacity;
        public bool inAir = true;
        public bool permission = false;
        private static int id = 0;
        public Airplane()
        {
            id++;
            this.PlaneFuel = 10;
        }

        public Airplane(int fuel)
        {
            this.PlaneFuel = fuel;
            this.TankCapacity = fuel;
        }

        public void RequestForPermission(ControlTower controlTower)
        {
            if (controlTower.isAnyFreeAirstrip())
                permission = true;
            else
            {
                permission = false;
                PlaneFuel--;
            }   
        }
        public void TryLand(Airstrip airstrip)
        {
            airstrip.isFree = false;
            this.inAir = false;
            Console.Write("PAS WOLNY ALE I TAK NIC NIE ZYJE");
        }
    }
}
