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
        private TimeOfDay TimeOfDay;
        public List<Animal> branch = new List<Animal>();
        public bool SpeakerActive = false;
        

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            TimeOfDay = timeOfDay;
            if (TimeOfDay == TimeOfDay.Fire)
            {
                if (_person != null)
                new RescueMission().Help(_presenter,_person,branch,SpeakerActive);
            }

            
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            
            switch (animalType)
            {

                case AnimalTypes.Bird:
                    if (TimeOfDay ==TimeOfDay.Day)
                    {
                        branch = new BranchPutter().PutAnimalOnBranch(animalType);
                        _presenter.WriteLine("Bird sit on the Tree.");
                    }
                    else
                    {
                        _presenter.WriteLine("Bird doesn't sit on the Tree.");
                    }

                    break;

                case AnimalTypes.Cat:
                    if (TimeOfDay == TimeOfDay.Night)
                    {
                        branch = new BranchPutter().PutAnimalOnBranch(animalType);
                        _presenter.WriteLine("Cat sit on the Tree.");
                    }
                    else
                    {
                        _presenter.WriteLine("Cat doesn't sit on the Tree.");
                    }

                    break;

                case AnimalTypes.Child:
                    if (TimeOfDay == TimeOfDay.Fire)
                    {
                        
                        _presenter.WriteLine("Child doesn't sit on the Tree.");
                    }
                    else
                    {
                        branch = new BranchPutter().PutAnimalOnBranch(animalType);
                        _presenter.WriteLine("Child sit on the Tree.");
                    }
                    break;


            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if (TimeOfDay == TimeOfDay.Fire) {
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
                    }
            else if (TimeOfDay == TimeOfDay.Day)
            {
                branch = new BranchPutter().PutAnimalsOnBranch(animalType);

                branch.RemoveAll(x => x.AnimalType == AnimalTypes.Cat);

            }
            else
            {
                branch = new BranchPutter().PutAnimalsOnBranch(animalType);
                branch.RemoveAll(x => x.AnimalType == AnimalTypes.Bird);

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
