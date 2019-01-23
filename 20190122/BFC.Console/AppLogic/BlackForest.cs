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
        private List<Animal> branch = new List<Animal>();
        TimeOfDay timeOfDay;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            this.timeOfDay = timeOfDay;
            if(timeOfDay == TimeOfDay.Fire)
            {
                if(_person is Romantic)
                {
                    if (CheckIfBranchContainsAnimalType(AnimalTypes.Child))
                        _presenter.WriteLine("Child will be rescued by Romantic.");
                }
                ActivateFireman();
            }
        }
        public bool CheckIfBranchContainsAnimalType(AnimalTypes type)
        {
            foreach(Animal animal in branch)
            {
                if (animal.AnimalType == type) return true;
            }
            return false;
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            bool isPossibleToSit = true;
            if (timeOfDay == TimeOfDay.Fire)
                isPossibleToSit = false;
            if (animalType == AnimalTypes.Cat && timeOfDay != TimeOfDay.Night)
                isPossibleToSit = false;
            else if (animalType == AnimalTypes.Bird && timeOfDay != TimeOfDay.Day)
                isPossibleToSit = false;
            branch.Add(new Animal(animalType.ToString(), animalType, true));
            string information = isPossibleToSit ? animalType.ToString() + " sit on the Tree." : animalType.ToString() + " doesn't sit on the Tree.";
            _presenter.WriteLine(information);
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if (timeOfDay != TimeOfDay.Fire)
            {
                foreach (AnimalTypes animal in animalType)
                    SitOnTheTree(animal);
            }
            else
            { 
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
                _presenter.WriteLine("Nobody will be rescued by Romantic.");
            }
        }

        public void ActivateFireman()
        {
            _person = new Fireman();
            if (CheckIfBranchContainsAnimalType(AnimalTypes.Bird))
                _presenter.WriteLine("Fireman generated alarm sound.");
            if (branch.Count == 1 && CheckIfBranchContainsAnimalType(AnimalTypes.Bird))
                _presenter.WriteLine("Nobody will be rescued by Fireman.");
            if (CheckIfBranchContainsAnimalType(AnimalTypes.Child) && CheckIfBranchContainsAnimalType(AnimalTypes.Cat))
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");
            _person.RescuAnimals(branch);
          
        }

        public void ActivateRomantic()
        {
            _person = new Romantic();            
        }
    }
}
