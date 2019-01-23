using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private List<Person> _people;
        private TimeOfDay _timeOfDay;
        private IList<Animal> animalsOnBranch;
        private Speaker _speaker;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
            _people = new List<Person>();
            animalsOnBranch = new List<Animal>();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;
            foreach(var person in _people)
            {
                if (person != null) person.DisplayActionInformation(animalsOnBranch);
                if (timeOfDay == TimeOfDay.Fire && animalsOnBranch.Any())
                {
                    person.RescueAnimals(animalsOnBranch);
                    if (animalsOnBranch
                        .Where(x => x.AnimalType == AnimalTypes.Bird)
                        .Any() && person is Fireman)
                    {
                        ActivateLowTuneSpeaker();
                        _speaker.GenerateSound();
                        animalsOnBranch.Clear();
                    }
                }
            }            
        }
        private void ActivateLowTuneSpeaker()
        {
            _speaker = new LowTuneSpeaker(_presenter);
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            string information = "";
            switch(animalType)
            {
                case AnimalTypes.Cat:
                    information = CanCatSitOnTheTree();
                    break;
                case AnimalTypes.Bird:
                    information = CanBirdSitOnTheTree();
                    break;
                case AnimalTypes.Child:
                    information = CanChildSitOnTheTree();
                    break;
                default:
                    break;
            }
            _presenter.WriteLine(information);
        }

        private string CanChildSitOnTheTree()
        {
            if (_timeOfDay == TimeOfDay.Fire)
            {
                return "Child doesn't sit on the Tree.";
            }
            else
            {
                animalsOnBranch.Add(new Animal("", AnimalTypes.Child));
                return "Child sit on the Tree.";
            }
        }

        private string CanBirdSitOnTheTree()
        {
            if(_timeOfDay == TimeOfDay.Day)
            {
                animalsOnBranch.Add(new Animal("", AnimalTypes.Bird));
                return "Bird sit on the Tree.";
            }
            else
            {
                return "Bird doesn't sit on the Tree.";
            }
        }

        private string CanCatSitOnTheTree()
        {
            if(_timeOfDay == TimeOfDay.Night)
            {
                animalsOnBranch.Add(new Animal("", AnimalTypes.Cat));
                return "Cat sit on the Tree.";
            }
            else
            {
                return "Cat doesn't sit on the Tree.";
            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if(_timeOfDay == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
            }
            else
            {
                foreach (var animal in animalType)
                {
                    SitOnTheTree(animal);
                }
            }            
        }

        public void ActivateFireman()
        {
            _people.Add(new Fireman(_presenter));
        }

        public void ActivateRomantic()
        {
            _people.Insert(0,new Romantic(_presenter));
        }
        public void TryToActivateRomantic(IProbablilityOfRomantic randomRomantic)
        {
            if(randomRomantic.Draw())
            {
                ActivateRomantic();
            }
        }
    }
}
