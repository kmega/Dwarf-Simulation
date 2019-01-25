using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Heroes;
using BFC.Console.Presentation;

namespace TheForest.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new WindowsConsole();
            var theForrest = new BlackForest(console);

            var animals = new[] { AnimalTypes.Bird, AnimalTypes.Cat, AnimalTypes.Child};
            theForrest.SitOnTheTree(animals);
            theForrest.ActivateFireman();
            theForrest.SetTimeOfDay(TimeOfDay.Fire);
            
            

            System.Console.ReadKey();

        }
    }
}
