using System;
using System.Collections.Generic;

namespace AirFlightSimulator
{
    public class LandingLanesManagementSystem
    {
        public List<LandingLane> AvailabeLanesForLanding = new List<LandingLane>
        {
            new LandingLane("asd123", true, 0)
        };


        public LandingLane GetLandingLane(Planes plane)
        {
            LandingLane AvailabeLane = new LandingLane("null", false, -1);

            foreach (LandingLane singleLaneFromCollection in AvailabeLanesForLanding)
            {
                if (singleLaneFromCollection.isAvailableForLanding is true)
                {
                    new ConsoleOutput().DisplayStatus(plane, singleLaneFromCollection);
                    AvailabeLane = singleLaneFromCollection;
                    SetLaneOccupancy(singleLaneFromCollection);
                }
            }

            return AvailabeLane;
        }

        private void SetLaneOccupancy(LandingLane singleLaneFromCollection)
        {
            singleLaneFromCollection.isAvailableForLanding = false;
            singleLaneFromCollection.waitingRoundsLeft = 5;
        }
    }
}



