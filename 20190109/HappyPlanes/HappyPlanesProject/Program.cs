using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPlanes.Entities;

namespace HappyPlanesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane = PlaneFactory.Create(PlaneLocation.InAir);
            Runway runway = new Runway("Runway 01", RunwayStatus.Empty);

            
       }
    }
}
