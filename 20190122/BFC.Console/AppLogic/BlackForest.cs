using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System.Linq;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {
        private IOutputWritter _presenter;
        private Person _person;
        private TimeOfDay _timeOfDay;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;
            //if (_person.GetType().Name == "Romantic" && timeOfDay == TimeOfDay.Fire)
            //{
            //}
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            if (animalType == AnimalTypes.Bird && _timeOfDay == TimeOfDay.Day)
            {
                _presenter.WriteLine("Bird sit on the Tree.");
            }
            if (animalType == AnimalTypes.Bird && _timeOfDay == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Bird doesn't sit on the Tree.");
            }
            if (animalType == AnimalTypes.Bird && _timeOfDay == TimeOfDay.Night)
            {
                _presenter.WriteLine("Bird doesn't sit on the Tree.");
            }
            if (animalType == AnimalTypes.Cat && _timeOfDay == TimeOfDay.Day)
            {
                _presenter.WriteLine("Cat doesn't sit on the Tree.");
            }
            if (animalType == AnimalTypes.Cat && _timeOfDay == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Cat doesn't sit on the Tree.");
            }
            if (animalType == AnimalTypes.Cat && _timeOfDay == TimeOfDay.Night)
            {
                _presenter.WriteLine("Cat sit on the Tree.");
            }
            if (animalType == AnimalTypes.Child && _timeOfDay == TimeOfDay.Day || _timeOfDay == TimeOfDay.Night)
            {
                _presenter.WriteLine("Child sit on the Tree.");
            }
            if (animalType == AnimalTypes.Child && _timeOfDay == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Child doesn't sit on the Tree.");
            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if (animalType.Length > 0 && _timeOfDay == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
            }
            if (animalType.Select(p => p == AnimalTypes.Bird).Any())
            {
                _presenter.WriteLine("Nobody will be rescued by Fireman.");
            }
            if (animalType.Select(p => p == AnimalTypes.Child).Any() && animalType.Select(p => p == AnimalTypes.Cat).Any())
            {
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");
            }
            if (animalType.Select(p => p == AnimalTypes.Bird).Any())
            {
                _presenter.WriteLine("Fireman generated alarm sound.");
            }
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