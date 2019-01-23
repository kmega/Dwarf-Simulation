using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System;
using System.Collections.Generic;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private Person _fireman;
        private Person _romantic;
        private TimeOfDay _timeOfDay;
        private List<Animal> AnimalsSittingOnTheTree = new List<Animal>();

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;

            Random r = new Random();
            if (r.Next(0, 2) == 0)
            {
                RomanticToTheRescue();
            }

            if (timeOfDay == TimeOfDay.Fire)
            {
                FiremanToTheRescue();
            }
        }

        private void RomanticToTheRescue()
        {
            ActivateRomantic();
            bool romanticIsInterestedInRescue = false;

            if (_timeOfDay != TimeOfDay.Fire)
            {
                for (int i = 0; i < AnimalsSittingOnTheTree.Count; i++)
                {
                    if (AnimalsSittingOnTheTree[i].AnimalType == AnimalTypes.Child)
                    {
                        if (romanticIsInterestedInRescue == false)
                        {
                            romanticIsInterestedInRescue = true;
                            _presenter.WriteLine("Child will be rescued by Romantic.");
                        }
                        _romantic.RescueAnimals(AnimalsSittingOnTheTree);
                    }
                }
            }
            else
            {
                _presenter.WriteLine("Nobody will be rescued by Romantic.");
            }
        }

        public void FiremanToTheRescue()
        {
            if (AnimalsSittingOnTheTree.Count > 0)
            {
                ActivateFireman();
                bool soundGenerated = false;
                string typesSaved = "";

                for (int i = 0; i < AnimalsSittingOnTheTree.Count; i++)
                {
                    if (AnimalsSittingOnTheTree[i].AnimalType == AnimalTypes.Bird)
                    {
                        if (soundGenerated == false)
                        {
                            soundGenerated = true;
                            _presenter.WriteLine("Fireman generated alarm sound.");
                        }
                        AnimalsSittingOnTheTree.RemoveAt(i);

                        if (AnimalsSittingOnTheTree.Count == 0)
                        {
                            _presenter.WriteLine("Nobody will be rescued by Fireman.");
                        }
                    }
                    else
                    {
                        for (int j = 0; j < AnimalsSittingOnTheTree.Count; j++)
                        {
                            if (j != AnimalsSittingOnTheTree.Count - 1)
                            {
                                typesSaved += AnimalsSittingOnTheTree[j] + ", ";
                            }
                            else
                            {
                                typesSaved += AnimalsSittingOnTheTree[j];
                            }
                        }

                        _presenter.WriteLine(typesSaved + " will be rescued by Fireman.");

                        _fireman.RescueAnimals(AnimalsSittingOnTheTree);
                    }
                }
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
            _fireman = new Fireman();
        }

        public void ActivateRomantic()
        {
            _romantic = new Romantic();
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
