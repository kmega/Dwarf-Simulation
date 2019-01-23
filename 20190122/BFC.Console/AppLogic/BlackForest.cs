using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {
        private IOutputWritter _presenter;
        private Person _person;
        private TimeOfDay _timeOfDay;
        private AnimalTypes _animalOnBranch;
        private IList<Animal> _animalList;

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            try
            {
                if (_animalList.Count != 0 && _timeOfDay == TimeOfDay.Night && timeOfDay == TimeOfDay.Fire)
                {
                    string[] tmp = new string[_animalList.Count];
                    for (int i = 0; i < _animalList.Count; i++)
                    {
                        tmp[i] = _animalList[i].ToString();
                    }
                    string message = string.Join(", ", tmp);
                    _presenter.WriteLine($"{message} will be rescued by Fireman.");
                }

                if (_animalList.Count != 0 && timeOfDay == TimeOfDay.Fire)
                {
                    string[] tmp = new string[_animalList.Count];
                    for (int i = 0; i < _animalList.Count; i++)
                    {
                        tmp[i] = _animalList[i].ToString();
                    }
                    string message = string.Join(", ", tmp);

                        ActivateFireman();

                        _person.RescuAnimals(_animalList);

                        int counter = 0;

                        for (int i = 0; i < tmp.Length; i++)
                        {
                            if (tmp[i] == AnimalTypes.Bird.ToString())
                            {
                                counter++;
                            }
                        }

                        if (counter == tmp.Length)
                        {
                            _presenter.WriteLine("Nobody will be rescued by Fireman.");
                            _presenter.WriteLine("Fireman generated alarm sound.");
                    }
                        else
                            _presenter.WriteLine($"{message} doesn't sit on the Tree");
                    

                    _timeOfDay = timeOfDay;
                }
            }
            catch (System.Exception)
            {

                _timeOfDay = timeOfDay;
            }

        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            _animalOnBranch = animalType;
 
            switch (_timeOfDay)
            {
                case TimeOfDay.Day:
                    if (animalType == AnimalTypes.Cat)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Bird)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    if (animalType == AnimalTypes.Child)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    break;

                case TimeOfDay.Night:
                    if (animalType == AnimalTypes.Cat)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    if (animalType == AnimalTypes.Bird)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Child)
                        _presenter.WriteLine($"{animalType} sit on the Tree.");
                    break;

                case TimeOfDay.Fire:
                    if (animalType == AnimalTypes.Cat)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Bird)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    if (animalType == AnimalTypes.Child)
                        _presenter.WriteLine($"{animalType} doesn't sit on the Tree.");
                    break;
            }
        }


        public void SitOnTheTree(AnimalTypes[] animalType)
        {
            BranchHelper branch = new BranchHelper();
            _animalList = branch.PutAnimalsOnBranch(animalType);

            string[] tmp = new string[_animalList.Count];
            for (int i = 0; i < _animalList.Count; i++)
            {
                tmp[i] = _animalList[i].ToString();
            }
            string message = string.Join(", ", tmp);


            if (_timeOfDay == TimeOfDay.Fire)
            {
                ActivateFireman();

                _person.RescuAnimals(_animalList);

                int counter = 0;

                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == AnimalTypes.Bird.ToString())
                    {
                        counter++;
                    }
                }

                if (counter == tmp.Length)
                {
                    _presenter.WriteLine("Nobody will be rescued by Fireman.");
                }
                else
                    _presenter.WriteLine($"{message} doesn't sit on the Tree");

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

    internal class BranchHelper
    {

        public IList<Animal> PutAnimalOnBranch(AnimalTypes animalType)
        {
            return new List<Animal>()
                {
                    new Animal(animalType.ToString(), animalType)
                };

        }

        public IList<Animal> PutAnimalsOnBranch(AnimalTypes[] animalTypes)
        {
            IList<Animal> animals = new List<Animal>();
            animalTypes.ToList().ForEach(a => animals.Add(new Animal(a.ToString(), a)));
            return animals;
        }
    }
}

