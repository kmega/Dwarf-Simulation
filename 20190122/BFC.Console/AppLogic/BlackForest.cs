using System.Collections.Generic;
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
        private List<AnimalTypes> _AnimalsOnBranch = new List<AnimalTypes>();

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole(); //jesli lewa strona jest nullem, to wykona sie prawa
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;

            if (_timeOfDay == TimeOfDay.Fire && _AnimalsOnBranch.Count == 0)
            {
                _presenter.WriteLine("Nobody will be rescued by Romantic.");
            }

            if (_timeOfDay == TimeOfDay.Fire && _AnimalsOnBranch.Count != 0)
            {
                List<Animal> ListOfAnimalsToBeRescuedByFireman = new List<Animal>();

                SetListWithCertainAnimalTypes(ListOfAnimalsToBeRescuedByFireman, AnimalTypes.Bird);

                _person.RescuAnimals(ListOfAnimalsToBeRescuedByFireman);
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");
            }

            if (_timeOfDay == TimeOfDay.Fire && _AnimalsOnBranch.Count != 0)
            {
                List<Animal> ListOfAnimalsToBeRescuedByPedofil = new List<Animal>();

                SetListWithCertainAnimalTypes(ListOfAnimalsToBeRescuedByPedofil, AnimalTypes.Child);

                if (ListOfAnimalsToBeRescuedByPedofil.Count != 0)
                {
                    _person.RescuAnimals(ListOfAnimalsToBeRescuedByPedofil);
                    _presenter.WriteLine("Child will be rescued by Romantic.");
                }
                _presenter.WriteLine("Nobody will be rescued by Fireman.");
                _presenter.WriteLine("Fireman generated alarm sound.");
            }
        }

        private void SetListWithCertainAnimalTypes(List<Animal> ListWithCertainAnimals, AnimalTypes animalTypes)
        {
            foreach (var AniamlType in _AnimalsOnBranch)
            {
                if (AniamlType == animalTypes)
                    ListWithCertainAnimals.Add(new Animal(AniamlType.ToString(), AniamlType));
            }
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            _AnimalsOnBranch.Add(animalType);
            BranchSetter(animalType);
        }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            if (_timeOfDay == TimeOfDay.Fire && _AnimalsOnBranch.Count == 0)
            {
                _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
            }
            else
            {
                foreach (var item in animalType)
                {
                    BranchSetter(item);
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

        private void BranchSetter(AnimalTypes animalType)
        {
            switch (animalType)
            {
                case AnimalTypes.Child:
                    switch (_timeOfDay)
                    {
                        case TimeOfDay.Day:
                            _AnimalsOnBranch.Add(animalType);
                            _presenter.WriteLine("Child sit on the Tree.");
                            break;
                        case TimeOfDay.Night:
                            _AnimalsOnBranch.Add(animalType);
                            _presenter.WriteLine("Child sit on the Tree.");
                            break;
                        case TimeOfDay.Fire:
                            _presenter.WriteLine("Child doesn't sit on the Tree.");
                            break;
                    }
                    break;

                case AnimalTypes.Bird:
                    switch (_timeOfDay)
                    {
                        case TimeOfDay.Day:
                            _AnimalsOnBranch.Add(animalType);
                            _presenter.WriteLine("Bird sit on the Tree.");
                            break;
                        case TimeOfDay.Night:
                            _presenter.WriteLine("Bird doesn't sit on the Tree.");
                            break;
                        case TimeOfDay.Fire:
                            _presenter.WriteLine("Bird doesn't sit on the Tree.");
                            break;
                    }
                    break;
                case AnimalTypes.Cat:
                    switch (_timeOfDay)
                    {
                        case TimeOfDay.Day:
                            _presenter.WriteLine("Cat doesn't sit on the Tree.");
                            break;
                        case TimeOfDay.Night:
                            _AnimalsOnBranch.Add(animalType);
                            _presenter.WriteLine("Cat sit on the Tree.");
                            break;
                        case TimeOfDay.Fire:
                            _presenter.WriteLine("Cat doesn't sit on the Tree.");
                            break;
                    }
                    break;
            }

            }
        }
}