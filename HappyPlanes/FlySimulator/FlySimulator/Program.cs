using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightTower flightTower = new FlightTower();



        
                if (flightTower.AreEmptyRunways())
                {
                    var plane = flightTower.airPlanes[0];
                    flightTower.TakeThePlane(plane);
                }
            

          



            Console.ReadKey();

        }


    }
               

            

         
         
}
