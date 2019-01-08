using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class FlySymulator
    {
        List<AirPlane> Planes;
        List<LandBelts> Belts;
        public Stats stats = new Stats();
        public void Run()
        {
            //Tworzy samoloty i pasy
            DataCreation(out Planes, out Belts);

            //Załaduj Wolne utworzone Pasy Do informacji wieży o pasach 
            // Belts -> Tower.FreeBelts
            FlightTower Tower = new FlightTower()
            {
                FreeLandBelts = Belts
            };

            //Tworzy listę samolotów w powietrzu
            var AirPlanesOnTheAir = Planes.FindAll(x => x.OnTheAir == true).ToList();
            //Tworzy listę samolotów na ziemi
            var AirPlanesOnTheLand = Planes.FindAll(x => x.OnTheAir == false).ToList();

            //Wykonuje 1000 tur
            PerformTours(Tower, AirPlanesOnTheAir, AirPlanesOnTheLand,100);
        }

        private void PerformTours(FlightTower Tower, List<AirPlane> AirPlanesOnTheAir, List<AirPlane> AirPlanesOnTheLand,int iterations)
        {
         
            for (int i = 0; i < iterations; i++)
            {
                SubstractFuel(AirPlanesOnTheAir);
                CheckDoesAnyFuelIsNegative(AirPlanesOnTheAir);
                //Usuń jedno paliwo z każdego samolotu w powietrzu

                if (!AirPlanesOnTheAir.Any() && !AirPlanesOnTheLand.Any())
                {
                    stats.IterationCount = i;
                    break;
                }
                

                Console.Write(i + "- " + "Ilość wolnych pasów: " + Tower.FreeLandBelts.Count + "\n");
                if (i >= 3)
                {
                    //Samolot pyta o wolne miejsce a wieża odpowiada
                    CommunicatiorTowerAirplane(Tower, AirPlanesOnTheAir);

                    //Jeśli ma miejsce to przydziela pas do lądowania
                    Tower.ManagementOfLandingAssignment(AirPlanesOnTheAir, AirPlanesOnTheLand);

                    //Jeśli piąta tura to wypuść jeden samolot w powietrze
                    IfTourIsFiveThenSetFreeStrip(Tower, AirPlanesOnTheAir, AirPlanesOnTheLand, i);

                    //Zwieksz paliwo w kazdym saomolcie na ziemi
                    RefuelPlainsOnGround(AirPlanesOnTheLand);
                }
            }

        }

        private void SubstractFuel(List<AirPlane> airPlanesOnTheAir)
        {
            foreach (AirPlane airPlane in airPlanesOnTheAir)
                airPlane.SubstractFuel();
        }
        private void RefuelPlainsOnGround(List<AirPlane> airPlanesOnTheLand)
        {
            foreach (AirPlane airPlane in airPlanesOnTheLand)
                airPlane.RefuelPlain();
        }

        private static void DataCreation(out List<AirPlane> Planes, out List<LandBelts> Belts)
        {
            //Buduj Listę samolotów -> List<Airplane>
            Factory Factory = new Factory();
            Planes = FakeFactory.generatePlanes();

            //Buduj Listę pasów -> List<LandBelt>
            Belts = Factory.MakeLandBelts(2);
        }

      

        private static void IfTourIsFiveThenSetFreeStrip(FlightTower Tower, List<AirPlane> AirPlanesOnTheAir, List<AirPlane> AirPlanesOnTheLand, int i)
        {
            if ((i % 5 == 0) && i > 0)
            {
                //Usuń samolot z ziemi
                AirPlanesOnTheLand[0].OnTheAir = true;

                AirPlanesOnTheAir.Add(AirPlanesOnTheLand[0]);
                AirPlanesOnTheLand.Remove(AirPlanesOnTheLand[0]);

                //Wyczyść pas startowy
                Tower.SetFreeOneBelt();
            }
        }

        private static void CommunicatiorTowerAirplane(FlightTower Tower, List<AirPlane> AirPlanesOnTheAir)
        { 
            // Pozwolenie na lądowanie
            AirPlanesOnTheAir[0].OnTheAir = Tower.GivePermissionToLanding();
        }
        public void CheckDoesAnyFuelIsNegative(List<AirPlane> Planes)
        {
            List<AirPlane> DeadPlanes = Planes.Where(x => x.Fuel < 0).ToList();
            stats.DestroyedPlanes.AddRange(DeadPlanes);
            foreach (var item in DeadPlanes)
            {
                Planes.Remove(item);
            }

        }
    }
        
}
