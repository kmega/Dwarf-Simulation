using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class FlySymulator
    {

        public void Run()
        {
            //Buduj Listę samolotów -> List<Airplane>
            Factory Factory = new Factory();
            List<AirPlane> Planes = Factory.MakeAirplanes(50);

            //Buduj Listę pasów -> List<LandBelt>
            List<LandBelts> Belts = Factory.MakeLandBelts(10);

            //Załaduj Wolne utworzone Pasy Do informacji wieży o pasach 
            // Belts -> Tower.FreeBelts
            FlightTower Tower = new FlightTower()
            {
                FreeLandBelts = Belts
            };

            var AirPlanesOnTheAir = Planes.FindAll(x => x.OnTheAir == true).ToList();
            var AirPlanesOnTheLand = Planes.FindAll(x => x.OnTheAir == false).ToList();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(i + "- " + "Ilość wolnych pasów: " + Tower.FreeLandBelts.Count + "\n");

                //Samolot pyta wieżę czy może podejść do lądowania
                AirPlanesOnTheAir[0].PermissionLandingAsk(AirPlanesOnTheAir[0].Name);
                //Wieża odpowiada czy ma miejsce
                AirPlanesOnTheAir[0].PermissionToLanding = Tower.GivePermissionToLanding();

                //Jeśli ma miejsce to przydziela pas do lądowania
                if (AirPlanesOnTheAir[0].PermissionToLanding == true)
                {
                    //Przdziela samolotowi pas do lądowania
                    AirPlanesOnTheAir[0].LandBelt = Tower.GiveFreeLandBelt();

                    AirPlanesOnTheAir[0].LandingSucces = true;
                    AirPlanesOnTheAir[0].OnTheAir = false;

                    AirPlanesOnTheLand.Add(AirPlanesOnTheAir[0]);
                    AirPlanesOnTheAir.Remove(AirPlanesOnTheAir[0]);
                }
                else
                {
                    Tower.MessageToPilotThatCantLandin();
                }

                //Jeśli piąta tura to wypuść jeden samolot w powietrze
                if ((i % 5 == 0) && i > 0)
                {
                    //Usuń samolot z ziemi
                    AirPlanesOnTheLand[0].OnTheAir = true;
                    AirPlanesOnTheLand[0].PermissionToLanding = false;

                    AirPlanesOnTheAir.Add(AirPlanesOnTheLand[0]);
                    AirPlanesOnTheLand.Remove(AirPlanesOnTheLand[0]);

                    //Wyczyść pas startowy
                    Tower.SetFreeOneBelt();
                }

                //Usuń jedno paliwo z każdego samolotu w powietrzu
                foreach (var Plane in AirPlanesOnTheAir)
                {
                    Plane.Fuel--;
                }

                CheckDoesAnyFuelIsNegative(Planes);

            }
        }

        public void CheckDoesAnyFuelIsNegative(List<AirPlane> Planes)
        {
            List<AirPlane> fuelNegative = Planes.Where(x => x.Fuel < 0).ToList();
            if (fuelNegative.Count > 0) throw new NotImplementedException();
        }
    }
        
}
