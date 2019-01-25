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
        private TimeOfDay time;
       

        List<AnimalTypes> animalsList = new List<AnimalTypes>();



        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            time = timeOfDay;
            bool isBird = animalsList.Contains(AnimalTypes.Bird);
            bool isCat = animalsList.Contains(AnimalTypes.Cat);
            bool isChild = animalsList.Contains(AnimalTypes.Child);

            if (isBird== true && timeOfDay == TimeOfDay.Fire && _person is Fireman)
                _presenter.WriteLine("Fireman generated alarm sound.");

            if (isCat == true && isChild == true && timeOfDay == TimeOfDay.Fire && _person is Fireman)
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");

            if (isCat == false && isChild == false && isBird == true && timeOfDay == TimeOfDay.Fire && _person is Fireman)
                _presenter.WriteLine("Nobody will be rescued by Fireman.");

            if (time == TimeOfDay.Fire && isChild == true && _person is Romantic)
                _presenter.WriteLine("Child will be rescued by Romantic.");
                        

        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            if (time == TimeOfDay.Fire)
            {
                if (animalType == AnimalTypes.Bird)
                    _presenter.WriteLine("Bird doesn't sit on the Tree.");
                if (animalType == AnimalTypes.Cat)
                    _presenter.WriteLine("Cat doesn't sit on the Tree.");
                if (animalType == AnimalTypes.Child)
                    _presenter.WriteLine("Child doesn't sit on the Tree.");

            }
            if (time == TimeOfDay.Day)
            {
                if (animalType == AnimalTypes.Cat)
                    _presenter.WriteLine("Cat doesn't sit on the Tree.");
                if (animalType == AnimalTypes.Child)
                    _presenter.WriteLine("Child sit on the Tree.");
                if (animalType == AnimalTypes.Bird)
                    _presenter.WriteLine("Bird sit on the Tree.");
            }
            if (time == TimeOfDay.Night)
            {
                if (animalType == AnimalTypes.Cat)
                    _presenter.WriteLine("Cat sit on the Tree.");
                if (animalType == AnimalTypes.Child)
                    _presenter.WriteLine("Child sit on the Tree.");
                if (animalType == AnimalTypes.Bird)
                    _presenter.WriteLine("Bird doesn't sit on the Tree.");
            }
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            foreach (var item in animalType)
            {
                if (item == AnimalTypes.Bird && time == TimeOfDay.Day )
                    animalsList.Add(AnimalTypes.Bird);
                if (item == AnimalTypes.Cat && time == TimeOfDay.Night)
                    animalsList.Add(AnimalTypes.Cat);
                if (item == AnimalTypes.Child)
                    animalsList.Add(AnimalTypes.Child);
                if (time == TimeOfDay.Fire && item == AnimalTypes.Child)
                    _presenter.WriteLine("Nobody will be rescued by Romantic.");
                
            }

            if (time == TimeOfDay.Fire)
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
    }
}
