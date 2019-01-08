using System;
using System.Collections.Generic;

namespace AirTraffic
{
    class ControlTower : TrafficSystem
    {
        public void GetLaneForLanding(PlaneCreator plane, List<PlaneCreator> Planes)
        {
            SetLandingLaneForPlane(plane, Planes);
            DecreaseLaneOccupancyPerRound();
        }

        private void DecreaseLaneOccupancyPerRound()
        {
            foreach (LaneCreator singleLane in lane)
            {
                if(singleLane.takenForRounds > 0)
                {
                    singleLane.takenForRounds--;
                    if (singleLane.takenForRounds == 0)
                        singleLane.laneTakenStatus = false;
                }
            }
        }

        private void SetLaneOccupancyStatus(LaneCreator singleLandingLane)
        {
            singleLandingLane.takenForRounds = 4;
            singleLandingLane.laneTakenStatus = true;
        }

        private void SetLandingLaneForPlane(PlaneCreator plane, List<PlaneCreator> Planes)
        {
            LaneCreator returnLane = null;

            foreach (LaneCreator singleLandingLane in lane)
            {
                if (singleLandingLane.laneTakenStatus == false)
                {
                    new ConsoleOutput().DisplayLandingPlane(GetAmountOfAvailableLanes(), singleLandingLane, plane);
                    SetLaneOccupancyStatus(singleLandingLane);
                    RemovePlaneFromAwaitingUnitsInAir(plane, Planes);
                    DecreaseFuelInFlyingPlane(Planes);
                    break;
                }
                else if(AreAllLanesTaken())
                {
                    new ConsoleOutput().DisplayLandingPlane(GetAmountOfAvailableLanes(), singleLandingLane, plane);
                    DecreaseFuelInFlyingPlane(Planes);
                    break;
                }
            }

            //return returnLane;
        }

        private void DecreaseFuelInFlyingPlane(List<PlaneCreator> planes)
        {
            foreach (PlaneCreator plane in planes)
            {
                if(plane.number != null)
                    plane.fuel--;
            }
        }

        private void RemovePlaneFromAwaitingUnitsInAir(PlaneCreator plane, List<PlaneCreator> temp)
        {
            temp[temp.IndexOf(plane)].number = null;
        }

        private bool AreAllLanesTaken()
        {
            int size = lane.Count;
            int compare = 0;

            foreach (LaneCreator item in lane)
            {
                if (item.laneTakenStatus == true)
                    compare++;
            }

            if (compare == size)
                return true;
            else return false;
        }

        private int GetAmountOfAvailableLanes()
        {
            int amountOfFreeLanes = 0;

            foreach (LaneCreator singleLane in lane)
            {
                if (singleLane.laneTakenStatus == false)
                    amountOfFreeLanes++;
            }

            return amountOfFreeLanes;
        }
    }

   
}
