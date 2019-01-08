using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("UnitTestProject1")]

namespace Planes
{
    internal class Airport
    {
        private int landingInProgress = -1;

        internal void Simulation(int turns, int planes, int fuel, bool[] landingPlaces)
        {
            int[] timer = {
    5,
    5,
    5,
    5,
    5,
    5,
    5,
    5,
    5,
    5
   };
            for (int i = 0; i < turns; i++)
            {
                if (fuel == 0)
                {
                    throw new Exception("Planes crashed. No fuel left :V");
                }
                landingPlaces = FindClearLandingPlace(landingPlaces);
                if (landingInProgress > -1)
                {
                    for (int j = 0; j < timer.Length; j++)
                    {
                        timer[landingInProgress]--;
                        if (timer[landingInProgress] == 0)
                        {
                            timer[landingInProgress] = 5;
                        }
                    }
                }
                fuel--;
            }
        }

        internal bool[] FindClearLandingPlace(bool[] landingPlaces)
        {
            for (int i = 0; i < landingPlaces.Length; i++)
            {
                if (landingPlaces[i] == false)
                {
                    landingPlaces[i] = true;
                    break;
                }
                landingPlaces[i] = false;
            }
            landingInProgress++;
            return landingPlaces;
        }
    }
}