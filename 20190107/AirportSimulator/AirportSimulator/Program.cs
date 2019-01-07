using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Plain-> <AskForPlace (ControlTower)> -> Answer 
            //1.1  <IsEnable(LandingZone)> -> Answer
            //2.Answer -> Plain -> <Landing> 
            //2.1. ControlTower -> IsBlocked(LandingZone)

            ControlTower ct = new ControlTower();

            List<Plain> listofplain = new List<Plain>();

            for (int i = 0; i < 10; i++)
            {

                ct.landingzones.Add(new Runway() { number = i });
            };

            for (int i = 0; i < 50; i++)
            {
                listofplain.Add(new Plain(i+1));
            }

            for (int i = 0; i < 100; i++)
            {
               bool answer=  listofplain[0].AskForFreeRunaway(ct);
                if (answer)
                {
                    listofplain.RemoveAt(0);
                }
                foreach (var item in listofplain)
                {
                    item.LoseFuel();
                };
            
            };






            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
