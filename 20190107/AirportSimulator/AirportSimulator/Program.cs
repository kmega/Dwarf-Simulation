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


            List<Plain> listofplain = new List<Plain>();
            string content = new AirportSimulation().Simulate(listofplain, 50);
            Console.WriteLine(content);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
