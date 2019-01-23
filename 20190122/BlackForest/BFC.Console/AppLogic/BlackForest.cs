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
        private IReactVoice _reactVoice;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
            _people = new List<Person>();
            animalsOnBranch = new List<Animal>();
        }
        public BlackForest(IOutputWritter presenter, IReactVoice reactor)
        {
            _presenter = presenter ?? new WindowsConsole();
            _people = new List<Person>();
            _reactVoice = reactor;
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
                    var birds = animalsOnBranch
                        .Where(x => x.AnimalType == AnimalTypes.Bird).ToList();
                    if (birds.Any() && person is Fireman)
                    {
                        ActivateLowTuneSpeaker();    
                        for(int i = birds.Count; i > 0; i--)
                        {                            
                            _speaker.GenerateSound(birds[i-1]);                           
                        }
                        birds.Clear();
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
                var myVoice = _reactVoice.VoiceIReact();
                if(_reactVoice != null)
                {
                    animalsOnBranch.Add(new Animal("", AnimalTypes.Bird, myVoice));
                }
                else
                {
                    animalsOnBranch.Add(new Animal("", AnimalTypes.Bird));
                }
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
