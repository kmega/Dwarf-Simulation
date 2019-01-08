using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    public class Stats
    {
        public List<AirPlane> DestroyedPlanes = new List<AirPlane>();
        public int landingCount = 0;
        public int takeOfCount = 0;

        public int IterationCount { get; internal set; }

        public override string ToString()
        {
            string result = "Destroyed Planes: " + DestroyedPlanes.Count + $" landingCount {landingCount} ," +
                $" takeOfCount {takeOfCount} , IterationCount {IterationCount}";
            return result;
        }
    }
}
