using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private Person _person;
        private TimeOfDay _timeOfDay;
        private IList<Animal> _animals = new List<Animal>();

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;

            //if (_timeOfDay.Equals(TimeOfDay.Fire))
            //{
            //    ActivateFireman();
            //}
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            _animals = new List<Animal>()
            {
                new Animal(animalType.ToString(), animalType)
            };

            _presenter.WriteLine(_animals.First().DoesSitingOnBranch(_timeOfDay));
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            animalType.ToList().ForEach(
                a => {
                    _animals.Add(new Animal(a.ToString(), a));
                });

            if (_timeOfDay.Equals(TimeOfDay.Fire))
            {
                ActivateFireman();
            }

            //_person.RescuAnimals(_animals);
            //if (new System.Random().Next(0, 2) == 1)
            //{
            //    ActivateRomantic();
            //}

            _presenter.WriteLine(_animals.First().DoesSitingOnBranch(_timeOfDay));
        }

        public void ActivateFireman()
        {
            _person = new Fireman();
            _person.RescuAnimals(_animals);
            _presenter.WriteLine(_person.ListOfRescuedAnimals());
        }

        public void ActivateRomantic()
        {
            _person = new Romantic();
            //_person.RescuAnimals(_animals);
            //_presenter.WriteLine(_person.ListOfRescuedAnimals());
        }
    }
}
