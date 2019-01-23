using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;

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
            //throw new System.NotImplementedException();
            _timeOfDay = timeOfDay;
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            //throw new System.NotImplementedException();
            switch (_timeOfDay)
            {
                case TimeOfDay.Day:
                    switch (animalType)
                    {
                        case AnimalTypes.Bird:
                            _presenter.WriteLine("Bird sit on the Tree.");
                            break;
                        case AnimalTypes.Cat:
                            _presenter.WriteLine("Cat doesn't sit on the Tree.");
                            break;
                        case AnimalTypes.Child:
                            _presenter.WriteLine("Child sit on the Tree.");
                            break;
                    }
                    break;
                case TimeOfDay.Night:
                    switch (animalType)
                    {
                        case AnimalTypes.Bird:
                            _presenter.WriteLine("Bird doesn't sit on the Tree.");
                            break;
                        case AnimalTypes.Cat:
                            _presenter.WriteLine("Cat sit on the Tree.");
                            break;
                        case AnimalTypes.Child:
                            _presenter.WriteLine("Child sit on the Tree.");
                            break;
                    }
                    break;
                case TimeOfDay.Fire:
                    switch (animalType)
                    {
                        case AnimalTypes.Bird:
                            _presenter.WriteLine("Bird doesn't sit on the Tree.");
                            break;
                        case AnimalTypes.Cat:
                            _presenter.WriteLine("Cat doesn't sit on the Tree.");
                            break;
                        case AnimalTypes.Child:
                            _presenter.WriteLine("Child doesn't sit on the Tree.");
                            break;
                    }
                    break;
            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            throw new System.NotImplementedException();
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
