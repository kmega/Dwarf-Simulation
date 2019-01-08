using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class AirportTrafficControlTower
    {
        public AirportTrafficControlTower(Queue<Runway> runways)
        {
            EmptyRunways = runways;
            OccupiedRunways = new List<Runway>();
        }
        private List<Runway> OccupiedRunways { get; set; }
        private Queue<Runway> EmptyRunways { get; set; }

        public bool TryLand(Airplane plane)
        {
            Runway emptyRunway = CheckForEmptyRunways();
            if (emptyRunway != null)
            {
                plane.CoordinatesToLand = SendCoordinates(emptyRunway.Coordinates);
                OccupiedRunways.Add(emptyRunway);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Runway CheckForEmptyRunways()
        {
            if (EmptyRunways.Any())
            {
                return EmptyRunways.Dequeue();
            }      
            else
            {
                return null;
            }
        }

        public int SimulateLandingOfPlanesWithTurnsCounter(List<Airplane> airplanes, int turns)
        {
            int i = 0;
            while(i < turns)
            {
                if (i > 3)
                {
                    if (airplanes.Any())
                    {
                        var currentPlane = airplanes.First();
                        if (currentPlane.AmountOfFuel <= 2)
                        {
                            bool hasLanded = TryLand(currentPlane);
                            if (hasLanded)
                            {
                                airplanes.Remove(currentPlane);
                                return i;
                            }
                            MovePlanesOnTracks();
                        }
                    }
                }
                BurnFuel(airplanes);
                i++;
            }
            return i;
        }

        public bool RefuelPlane(Airplane airplane)
        {
            if(!(airplane.AmountOfFuel == airplane.FuelAtStart))
            {
                airplane.AmountOfFuel++;
                return false;
            }

            return true;
        }

        public void SimulateLandingOfPlanes(List<Airplane> airplanes)
        {
            int i = 0;
            while (i < 1000)
            {
                if (i > 3)
                {
                    if (airplanes.Any())
                    {
                        var currentPlane = airplanes.First();
                        bool hasLanded = TryLand(currentPlane);
                        if (hasLanded)
                        {
                            if (RefuelPlane(currentPlane))
                            {
                                airplanes.Remove(currentPlane);
                            }
                        }
                        MovePlanesOnTracks();
                    }
                }
                BurnFuel(airplanes);
                i++;
            }
        }

        private void MovePlanesOnTracks()
        {
            int indexToDelete = 0;
            bool anythingToDelete = false;
            for(int i =0; i<OccupiedRunways.Count; i++)
            {
                OccupiedRunways[i].TimeOfOccupation -= 1;
                if(OccupiedRunways[i].TimeOfOccupation<=0)
                {
                    anythingToDelete = true;
                    indexToDelete = i;
                }
            }
            if(anythingToDelete)
            {
                OccupiedRunways[indexToDelete].TimeOfOccupation = 5;
                EmptyRunways.Enqueue(OccupiedRunways[indexToDelete]);
                OccupiedRunways.Remove(OccupiedRunways[indexToDelete]);
                anythingToDelete = false;
            }
        }

        private void BurnFuel(List<Airplane> airplanes)
        {
            foreach(var plane in airplanes)
            {
                plane.AmountOfFuel--;
                if(plane.AmountOfFuel<0)
                {
                    throw new ArgumentException($"Ohh no! {plane.Id} has crashed!");
                }
            }
        }

        private int[] SendCoordinates(int[] coordinates)
        {
            return coordinates;
        }

    }
}
