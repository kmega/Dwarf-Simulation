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
        private AnimalTypes _animalOnBranch;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            _animalOnBranch = animalType;

            switch (_timeOfDay)
            {
                case TimeOfDay.Day:
                    if (animalType == AnimalTypes.Cat)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Bird)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    if (animalType == AnimalTypes.Child)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    break;

                case TimeOfDay.Night:
                    if (animalType == AnimalTypes.Cat)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    if (animalType == AnimalTypes.Bird)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Child)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    break;

                case TimeOfDay.Fire:
                    if (animalType == AnimalTypes.Cat)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Bird)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Child)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    break;
            }
        }


        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            BranchHelper branch = new BranchHelper();
            IList<Animal> animalList = new List<Animal>();

            animalList = branch.PutAnimalsOnBranch(animalType);


            if (_timeOfDay == TimeOfDay.Fire)
            {
                ActivateFireman();

                _person.RescuAnimals(animalList);


            }

            if (animalList.Count == 1)
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");

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

    internal class BranchHelper
    {

        public IList<Animal> PutAnimalOnBranch(AnimalTypes animalType)
        {
            return new List<Animal>()
                {
                    new Animal(animalType.ToString(), animalType)
                };

        }

        public IList<Animal> PutAnimalsOnBranch(AnimalTypes[] animalTypes)
        {
            IList<Animal> animals = new List<Animal>();
            animalTypes.ToList().ForEach(a => animals.Add(new Animal(a.ToString(), a)));
            return animals;
        }
    }
}

