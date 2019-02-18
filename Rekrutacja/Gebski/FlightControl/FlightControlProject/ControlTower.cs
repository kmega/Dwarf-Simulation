using System.Collections.Generic;
using System.Linq;

namespace FlightControlProject
{
    public class ControlTower
    {
        public ControlTower(List<Airplane> airplanes, List<Airstrip> airstrips)
        {
            Airplanes = airplanes;
            Airstrips = airstrips;
        }

        public List<Airplane> Airplanes { get; set; }

        public List<Airstrip> Airstrips { get; set; }

        public void RefuelAirplanesOnGround()
        {
            var airplanesOnGround = Airplanes.Where(p => p.IsInAir == false).ToList();
            foreach (var airplane in airplanesOnGround)
            {
                airplane.Fuel += 1;
            }
        }

        public void PlanesOnGroundWithFullOfFuelTakeOff()
        {
            var airplanesOnGround = Airplanes.Where(p => p.IsInAir == false).ToList();
            foreach (var airplane in airplanesOnGround)
            {
                if (airplane.Fuel == airplane.MaxFuel)
                {
                    airplane.IsInAir = true;
                    Airstrips.First(p => p.IsFree == false).IsFree = true;
                }
            }
        }

        public void RemoveDestroyedAirplanes()
        {
            foreach (var airplane in Airplanes.ToList())
            {
                if (airplane.Fuel == 0)
                {
                    Airplanes.Remove(airplane);
                    Stats.AirplanesDestroyed += 1;
                }
            }
        }

        public void PlaneLand()
        {
            Airplanes.Where(p => p.IsInAir == true).Where(p => p.Fuel == 1).First().IsInAir = false;
            Stats.AirplanesLand += 1;
            Airstrips.Where(p => p.IsFree == true).First().IsFree = false;
        }

        public bool CheckIfAirstripIsFree()
        {
            return Airstrips.Any(p => p.IsFree == true);
        }

        public void RemoveFuelFromAirplanesInAir()
        {
            var AirplanesInAir = Airplanes.Where(p => p.IsInAir == true).ToList();
            foreach (var airplane in AirplanesInAir)
            {
                airplane.Fuel -= 1;
            }
        }
    }
}