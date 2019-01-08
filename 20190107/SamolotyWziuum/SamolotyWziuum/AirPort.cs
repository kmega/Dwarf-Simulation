using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamolotyWziuum
{
    public class AirPort
    {
        public const int numberOfPlanes = 50;
        public List<Plane> listOfAllPlanes = new List<Plane>();
        public List<Plane> listOfPlanesInTheAir = new List<Plane>();
        
        public void RefreshAirPlanesStatus()
        {
            listOfPlanesInTheAir = listOfAllPlanes.FindAll(x => x.planeInAir).ToList();
        }

        public void CreateAirPlanes()
        {
            for(int i = 0; i < numberOfPlanes; i++)
            {
                Plane plane = new Plane(i);
                listOfAllPlanes.Add(plane);
            }
        }
    }
}
