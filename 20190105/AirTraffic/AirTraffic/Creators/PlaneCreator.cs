namespace AirTraffic
{
    public class PlaneCreator
    {
        public int MaxFuel;
        public int ActualFuel { get; set; }
        public string number;
        public bool InTheAir { get; set; }

        public PlaneCreator(string number, int maxFuel)
        {
            MaxFuel = maxFuel;
            ActualFuel = MaxFuel;
            this.number = number;
            InTheAir = true;
        }
    }
}
