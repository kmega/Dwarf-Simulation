namespace Planes
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = 1000, planes = 50, fuel = 200;
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
            airport.Simulation(turns, planes, fuel, landingPlaces);
        }
    }
}
