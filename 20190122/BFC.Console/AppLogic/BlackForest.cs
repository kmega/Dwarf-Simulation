using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private Person _person;
        List<Animal> Animals = new List<Animal>();
        List<Animal> AnimalsOnTheBranch = new List<Animal>();
        private TimeOfDay _timeOfDay = new TimeOfDay();

        public BlackForest(IOutputWritter presenter)
        {
            Animals.Add(new Animal("Cat", AnimalTypes.Cat, true));      
            Animals.Add(new Animal("Child", AnimalTypes.Child, true));      
            Animals.Add(new Animal("Bird", AnimalTypes.Bird, true));   
            
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            Random random = new Random();
            var n = random.Next(0, 1);

            _timeOfDay = timeOfDay;
            if(_timeOfDay == TimeOfDay.Fire)
            {               
                 if(n == 0) ActivateRomantic();
                 if(n == 1) ActivateFireman();


                _person.RescuAnimals(AnimalsOnTheBranch);
            }
            List<string> animalsWhoWhouldBeRescused = new List<string>();

            foreach (var animal in AnimalsOnTheBranch)
            {
                if(animal.shouldIBeSaved == true)
                animalsWhoWhouldBeRescused.Add(animal.ToString());
            }

            if (AnimalsOnTheBranch.Count == 0)
            {
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");
                if (n == 0) _presenter.WriteLine("Child will be rescued by Romantic.");
            }
            else
            {
                _presenter.WriteLine("Nobody will be rescued by Fireman.");
                if(AnimalsOnTheBranch.Any(x=>x.AnimalType == AnimalTypes.Bird))
                    _presenter.WriteLine("Fireman generated alarm sound.");
            }
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            if(_timeOfDay != TimeOfDay.Fire)
            AddAnimalsToTheBranch(animalType);

            DisplayInformation(animalType);

        }

        private void AddAnimalsToTheBranch(AnimalTypes animalType)
        {
            switch (animalType)
            {
                case AnimalTypes.Child:
                    AnimalsOnTheBranch.Add(new Animal("Child", animalType, true));
                    break;
                case AnimalTypes.Bird:
                    {
                        if (_timeOfDay != TimeOfDay.Night)
                            AnimalsOnTheBranch.Add(new Animal("Bird", animalType, true));
                    }
                    break;
                case AnimalTypes.Cat:
                    {
                        if (_timeOfDay == TimeOfDay.Night)
                            AnimalsOnTheBranch.Add(new Animal("Cat", animalType, true));
                    }                  
                    break;
                default:
                    break;
            }
        }

        private void DisplayInformation(AnimalTypes animalType)
        {

            switch (animalType)
            {
                case AnimalTypes.Child:
                    switch (_timeOfDay)
                    {
                        case TimeOfDay.Day:
                            _presenter.WriteLine("Child sit on the Tree.");
                            break;
                        case TimeOfDay.Night:
                            _presenter.WriteLine("Child sit on the Tree.");
                            break;
                        case TimeOfDay.Fire:
                            _presenter.WriteLine("Child doesn't sit on the Tree.");
                            break;
                        default:
                            break;
                    }

                    break;
                case AnimalTypes.Bird:
                    switch (_timeOfDay)
                    {
                        case TimeOfDay.Day:
                            _presenter.WriteLine("Bird sit on the Tree.");
                            break;
                        case TimeOfDay.Night:
                            _presenter.WriteLine("Bird doesn't sit on the Tree.");
                            break;
                        case TimeOfDay.Fire:
                            _presenter.WriteLine("Bird doesn't sit on the Tree.");
                            break;
                        default:
                            break;
                    }
                    break;
                case AnimalTypes.Cat:
                    {
                        switch (_timeOfDay)
                        {
                            case TimeOfDay.Day:
                                _presenter.WriteLine("Cat doesn't sit on the Tree.");
                                break;
                            case TimeOfDay.Night:
                                _presenter.WriteLine("Cat sit on the Tree.");
                                break;
                            case TimeOfDay.Fire:
                                _presenter.WriteLine("Cat doesn't sit on the Tree.");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if(_timeOfDay != TimeOfDay.Fire)
            {
                foreach (var animal in animalType)
                {
                    AddAnimalsToTheBranch(animal);
                }
            }
            else
            {
                _presenter.WriteLine("Nobody will be rescued by Romantic.");
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
    }
}
