using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("UnitTestProject1")]

namespace ConsoleApp4
{
    internal class Airport
    {
        internal void Simulation(int turns, int planes, bool[] landingPlaces)
        {
            for (int i = 0; i < turns; i++)
            {
                bool planeCanLand = FindClearLandingPlace(landingPlaces);
            }
        }

        internal bool FindClearLandingPlace(bool[] landingPlaces)
        {
            bool planeCanLand = false;
            for (int i = 0; i < landingPlaces.Length; i++)
            {
                if (landingPlaces[i] == false)
                {
                    landingPlaces[i] = true;
                    planeCanLand = true;
                }
            }
            return planeCanLand;
        }
    }
}