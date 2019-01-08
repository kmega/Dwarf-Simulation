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

                ct.landingzones.Add(new Runway() { number = i+1 });
            };

            for (int i = 0; i < 50; i++)
            {
                listofplain.Add(new Plain(i+1,200));
            }
            int iterator = 0;

            for (int i = 0; i < 1000; i++)
            {
                if (!(listofplain.Count == 0))
                {
                    //McPochrzest
                    var planeToLand = listofplain.OrderBy(x=>x.fueltank).First();
                    bool answer = planeToLand.AskForFreeRunaway(ct);
                    if (answer)
                    {
                        listofplain.RemoveAt(0);
                        iterator++;
                    }
                    int killedPlanes = Plain.LoseFuel(listofplain);
                    
                    ct.RunwayCleaner();

                }
                else
                {
                    break;
                }
            };
            Console.WriteLine("Samoloty wyl¹dowa³y po " + iterator + " turach");






            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
