using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System.Collections.Generic;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private Person _person;
        private TimeOfDay _timeOfDay;
        private List<Animal> AnimalsSittingOnTheTree = new List<Animal>();

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;

            if (AnimalsSittingOnTheTree.Count > 0)
            {
                ActivateFireman();

                for (int i = 0; i < AnimalsSittingOnTheTree.Count; i++)
                {
                    if (AnimalsSittingOnTheTree[i].AnimalType == AnimalTypes.Bird)
                    {
                        _presenter.WriteLine("Fireman generated alarm sound.");
                    }
                    else
                    {
                        _presenter.WriteLine("Nobody will be rescued by Fireman.");
                    }
                }

                _person.RescueAnimals(AnimalsSittingOnTheTree);
            }
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            CheckIfAnimalCanSit(animalType);
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if (_timeOfDay != TimeOfDay.Fire)
            {
                for (int i = 0; i < animalType.Length; i++)
                {
                    CheckIfAnimalCanSit(animalType[i]);
                }
            }
            else
            {
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
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

        public void CheckIfAnimalCanSit(AnimalTypes animalType)
        {
            if (_timeOfDay == TimeOfDay.Day)
            {
                if (animalType == AnimalTypes.Cat)
                {
                    _presenter.WriteLine(AnimalTypes.Cat + " doesn't sit on the Tree.");
                }
                else
                {
                    _presenter.WriteLine(animalType + " sit on the Tree.");
                    Animal animal = new Animal(animalType.ToString(), animalType, true);
                    AnimalsSittingOnTheTree.Add(animal);
                }
            }
            else if (_timeOfDay == TimeOfDay.Night)
            {
                if (animalType == AnimalTypes.Bird)
                {
                    _presenter.WriteLine(AnimalTypes.Bird + " doesn't sit on the Tree.");
                }
                else
                {
                    _presenter.WriteLine(animalType + " sit on the Tree.");
                    Animal animal = new Animal(animalType.ToString(), animalType, true);
                    AnimalsSittingOnTheTree.Add(animal);
                }
            }
            else
            {
                _presenter.WriteLine(animalType + " doesn't sit on the Tree.");
            }
        }
    }
}
