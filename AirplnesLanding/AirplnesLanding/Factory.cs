using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class Factory
    {
        private Random random = new Random();

        public List<AirPlane> MakeAirplanes(int CountPlanesToCreate)
        {
            
            List<AirPlane> CreatedPlanes = new List<AirPlane>();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < CountPlanesToCreate; i++)
            {
                string name = new string(Enumerable.Repeat(chars, 7)
                .Select(s => s[random.Next(s.Length)]).ToArray());

                CreatedPlanes.Add(new AirPlane(name));
            }

            return CreatedPlanes;

        }

        public List<LandBelts> MakeLandBelts(int CountBeltsToCreate)
        {
            List<LandBelts> CreatedBelts = new List<LandBelts>();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < CountBeltsToCreate; i++)
            {
                string name = new string(Enumerable.Repeat(chars, 7)
                .Select(s => s[random.Next(s.Length)]).ToArray());

                CreatedBelts.Add(new LandBelts(name));
            }

            return CreatedBelts;
        }
    }
}
