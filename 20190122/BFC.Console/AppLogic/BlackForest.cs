using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {
        private IOutputWritter _presenter;
        private Person _person;
        private TimeOfDay time;
        private bool _isbird = false;
        private bool _isCat = false;
        private bool _isChild = false;
        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            time = timeOfDay;
            if (time == TimeOfDay.Fire && _isbird == true)
            {
                _presenter.WriteLine("Fireman generated alarm sound.");
                _isbird = false;
            }
            if (_isbird == false && _isCat == false && _isChild == false)
            {
                _presenter.WriteLine("Nobody will be rescued by Fireman.");
            }
            if ((_isCat == true && _isChild == true) && time == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");
            }
            if (_isChild == true && time == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Child will be rescued by Romantic.");
            }
            
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            PlaceInTheForest(animalType);
            //cat
            if (!_isCat)
            {
                _presenter.WriteLine("Cat doesn't sit on the Tree.");
            }
            else if (_isCat)
            {
                _presenter.WriteLine("Cat sit on the Tree.");
            }
            //Bird
            if (!_isbird)
            {
                _presenter.WriteLine("Bird doesn't sit on the Tree.");
            }
            else if (_isbird)
            {
                _presenter.WriteLine("Bird sit on the Tree.");
            }
            //child
            if (_isChild)
            {
                _presenter.WriteLine("Child sit on the Tree.");
            }
            else if (!_isChild)
            {
                _presenter.WriteLine("Child doesn't sit on the Tree.");
            }
        }

        private void PlaceInTheForest(AnimalTypes animalType)
        {
            //poprawic nieczytelne 
            if (animalType == AnimalTypes.Bird && time == TimeOfDay.Day)
            {
                _isbird = true;
            }
            else if (animalType == AnimalTypes.Bird && (time == TimeOfDay.Night || time == TimeOfDay.Fire))
            {
                _isbird = false;
            }
            if (animalType == AnimalTypes.Child && (time == TimeOfDay.Day || time == TimeOfDay.Night))
            {
                _isChild = true;
            }
            else if (animalType == AnimalTypes.Child && time == TimeOfDay.Fire)
            {
                _isbird = false;
            }
            if (animalType == AnimalTypes.Cat && time == TimeOfDay.Night)
            {
                _isCat = true;
            }
            else if (animalType == AnimalTypes.Cat && (time == TimeOfDay.Day || time == TimeOfDay.Fire))
            {
                _isCat = false;
            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            PlaceInTheForestList(animalType);
            if (time == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
            }
            if (time == TimeOfDay.Fire)
            {
                _presenter.WriteLine("Nobody will be rescued by Romantic.");
            }


        }

        private void PlaceInTheForestList(AnimalTypes[] animalType)
        {
            for (int i = 0; i < animalType.Length; i++)
            {
                if (animalType[i] == AnimalTypes.Bird)
                {
                    _isbird = true;
                }
                if (animalType[i] == AnimalTypes.Cat)
                {
                    _isCat = true;
                }
                if (animalType[i] == AnimalTypes.Child)
                {
                    _isChild = true;
                }
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
