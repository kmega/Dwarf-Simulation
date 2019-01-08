using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    class FakeFactory
    {
        public static List<AirPlane> generatePlanes()
        {
            List<AirPlane> airPlanes = new List<AirPlane>();
           // airPlanes.Add(new AirPlane("Maciek1", 1));
            airPlanes.Add(new AirPlane("Maciek2", 4));
           // airPlanes.Add(new AirPlane("Maciek3", 3));
            //airPlanes.Add(new AirPlane("Maciek4", 4));
            //airPlanes.Add(new AirPlane("Maciek5", 2));
            //airPlanes.Add(new AirPlane("Maciek6", 1));
            //airPlanes.Add(new AirPlane("Maciek7", 1));
            //airPlanes.Add(new AirPlane("Maciek8", 1));
            //airPlanes.Add(new AirPlane("Maciek9", 1));
            //airPlanes.Add(new AirPlane("Maciek10", 1));
            return airPlanes;
        }
    }
}
