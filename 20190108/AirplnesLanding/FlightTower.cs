using System;
using System.Collections.Generic;

namespace HappyPlanes
{
    public class FlightTower
    {
        public bool PermissionToLanding { get; set; }
        public List<LandBelts> FreeLandBelts { get; set; } = new List<LandBelts>();
        public List<LandBelts> OccupiedLandBelts { get; set; } = new List<LandBelts>();

        public FlightTower()
        {
            PermissionToLanding = false;
        }

        public void ManagementOfLandingAssignment(List<AirPlane> AirPlanesOnTheAir, List<AirPlane> AirPlanesOnTheLand)
        {
            if (AirPlanesOnTheAir[0].OnTheAir == true)
            {
                //Przdziela samolotowi pas do lądowania
                AirPlanesOnTheAir[0].LandBelt = GiveFreeLandBelt();

                // Wylądował
                AirPlanesOnTheAir[0].OnTheAir = false;

                AirPlanesOnTheLand.Add(AirPlanesOnTheAir[0]);
                AirPlanesOnTheAir.Remove(AirPlanesOnTheAir[0]);
            }
            else
            {
                MessageToPilotThatCantLandin();
            }
        }

        public LandBelts GiveFreeLandBelt()
        {
            OccupiedLandBelts.Add(FreeLandBelts[0]);
            FreeLandBelts.Remove(FreeLandBelts[0]);

            return OccupiedLandBelts[OccupiedLandBelts.Count-1];
        }

        public bool GivePermissionToLanding()
        {
            if (FreeLandBelts.Count > 0)
            {
                Console.WriteLine($"Możesz podejść do lądowania\nPrzydzielam Ci pas {FreeLandBelts[0].Name} \n");
                return true;
            }

            return false;
            


        }

        public void MessageToPilotThatCantLandin()
        {
            Console.WriteLine("Wszystkie pasy są zajęte, utrzymuj się dalej w powietrzu!\n");
        }

        public void SetFreeOneBelt()
        {
            FreeLandBelts.Add(OccupiedLandBelts[0]);
            OccupiedLandBelts.Remove(OccupiedLandBelts[0]);
        }
    }
}