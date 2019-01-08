using System;
using System.Collections.Generic;

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

            for(int i =airplanes.Count - 1; i>=0; i--)
            {
                airplanes[i].fueltank -= 1;
                if (airplanes[i].fueltank <= 0)
                {
                    killedPlanes += 1;
                    airplanes.RemoveAt(i);
                }
            }
            
            return killedPlanes;
        }
    }
}
