namespace TeaApp
{
    public class Tea
    {
        public Tea(string name, string type, int temperature, int time)
        {
            Name = name;
            Type = type;
            TimeOfCooking = time;
            Temperature = temperature;
        }
        public string Name { get;private set; }
        public string Type { get;private set; }
        public int TimeOfCooking { get;private set; }
        public int Temperature { get;private set; }

    }
}