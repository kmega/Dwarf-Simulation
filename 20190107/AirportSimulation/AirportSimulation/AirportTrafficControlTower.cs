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
            if(emptyRunway != null)
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

        public void SimulateLandingOfPlanes(List<Airplane> airplanes)
        {
            int i = 1000;
            while(i>0)
            {
                if(airplanes.Any())
                {
                    var currentPlane = airplanes.First();
                    bool hasLanded = TryLand(currentPlane);
                    if (hasLanded)
                    {
                        airplanes.Remove(currentPlane);
                    }
                    BurnFuel(airplanes);
                    MovePlanesOnTracks();                   
                }
                i--;
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
                plane.AmountOfFuel -= 1;
                if(plane.AmountOfFuel<=0)
                {
                    throw new ArgumentException($"Ohh no! {airplanes.Count} has crashed!");
                }
            }
        }

        private int[] SendCoordinates(int[] coordinates)
        {
            return coordinates;
        }

    }
}
