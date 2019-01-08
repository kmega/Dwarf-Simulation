using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator
{
   public class Plain
    {
        public int plainnumber;
       public int fueltank;
        public int TankSize { get; private set; }

        public Plain(int number, int fuel)
        {
            plainnumber = number;
            fueltank = fuel;
            TankSize = fuel;
        }
      

        public bool AskForFreeRunaway (ControlTower ct)
        {
            bool answer = false;
            int answerrunawaynumber = ct.SearchFreeRunaway();

            if (!(answerrunawaynumber==0))
            {
                Landing(ct, answerrunawaynumber);
                answer = true;
            }
            return answer;
        }

        public void Landing (ControlTower ct,int number)
        {
            var selectedLandingZone = ct.landingzones.Find(x => x.number == number);
            selectedLandingZone.IsEnable = false;
            selectedLandingZone.BlockedTimer = TankSize - fueltank;
            Console.WriteLine("Samolot numer: " + plainnumber + " wylądowa na pasie " + number);
            Console.WriteLine("Miał " + fueltank + " paliwa");
        }

        public static int LoseFuel(List<Plain> airplanes)
        {
            int killedPlanes = 0;
            foreach(var plane in airplanes)
            {
                plane.fueltank -= 1;
                if(plane.fueltank <= 0)
                {
                    killedPlanes += 1;
                    airplanes.Remove(plane);
                }
            }
            return killedPlanes;
        }
    }
}
