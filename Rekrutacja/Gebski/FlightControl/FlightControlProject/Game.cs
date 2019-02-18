using System.Linq;

namespace FlightControlProject
{
    internal class Game
    {
        public static void StartGame(int turns)
        {
            var controlTower = new ControlTower(Airplane.CreateAirplanes(30, 5), Airstrip.CreateAirstrips(2));

            for (int i = 0; i < turns; i++)
            {
                controlTower.RemoveFuelFromAirplanesInAir();
                controlTower.RefuelAirplanesOnGround();
                controlTower.PlanesOnGroundWithFullOfFuelTakeOff();
                while (controlTower.CheckIfAirstripIsFree())
                {
                    if (controlTower.Airplanes.Where(p => p.Fuel == 1).Any())
                    {
                        controlTower.PlaneLand();
                    }
                    else
                    {
                        break;
                    }
                }
                controlTower.RemoveDestroyedAirplanes();
            }
        }
    }
}