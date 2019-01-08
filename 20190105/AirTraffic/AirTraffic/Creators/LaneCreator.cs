namespace AirTraffic
{
    public class LaneCreator
    {
        public string encryptedLaneName;
        public bool laneTakenStatus;
        public int takenForRounds;

        public LaneCreator(string encryptedLaneName, bool laneTakenStatus, int takenForRounds)
        {
            this.encryptedLaneName = encryptedLaneName;
            this.laneTakenStatus = laneTakenStatus;
            this.takenForRounds = takenForRounds;
        }
    }
}
