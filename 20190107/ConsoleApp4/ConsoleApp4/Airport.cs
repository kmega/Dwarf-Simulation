using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("UnitTestProject1")]

namespace Planes
{
    internal class Airport
    {
        private bool landingInProgress = false;

        internal void Simulation(int turns, int planes, int fuel, bool[] landingPlaces)
        {
            for (int i = 0; i < turns; i++)
            {
                landingPlaces = FindClearLandingPlace(landingPlaces);
                if (landingInProgress == true)
                {

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
            landingInProgress = true;
            return landingPlaces;
        }
    }
}