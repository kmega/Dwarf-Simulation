using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private Person _person;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            throw new System.NotImplementedException();
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            throw new System.NotImplementedException();
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            throw new System.NotImplementedException();
        }

        public void ActivateFireman()
        {
            _person = new Fireman();
        }

        public void ActivateRomantic()
        {
            _person = new Romantic();
        }
    }
}
