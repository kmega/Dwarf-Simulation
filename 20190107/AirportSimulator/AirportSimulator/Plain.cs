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
       public int fueltank = 200;

        public Plain(int number)
        {
            plainnumber = number;
           
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
            ct.landingzones.Find(x => x.number == number).IsEnable=false;
            Console.WriteLine("Samolot numer: " + plainnumber + " wylądowa na pasie " + number);
            Console.WriteLine("Miał " + fueltank + " paliwa");
        }

        public void LoseFuel()
        {
            fueltank -= 1;
        }
    }
}
