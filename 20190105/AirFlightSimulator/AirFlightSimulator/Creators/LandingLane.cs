namespace AirFlightSimulator
{
    public class LandingLane
    {
        public string lanePositionEncrypted;
        public bool isAvailableForLanding;
        public int waitingRoundsLeft;

        public LandingLane(string lanePositionEncrypted, bool isAvailableForLanding, int waitingRoundsLeft)
        {
            this.lanePositionEncrypted = lanePositionEncrypted;
            this.isAvailableForLanding = isAvailableForLanding;
            this.waitingRoundsLeft = waitingRoundsLeft;
        }
    }

}
