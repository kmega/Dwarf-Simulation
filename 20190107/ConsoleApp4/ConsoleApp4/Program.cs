namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = 1000;
            int planes = 50;
            bool[] landingPlaces = {
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false
            };
            
            Airport airport = new Airport();
            airport.Simulation(turns, planes, landingPlaces);
        }
    }
}
