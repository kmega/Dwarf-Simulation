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
        private TimeOfDay _timeOfDay;
        private List<Animal> _animals = new List<Animal>();

        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;

            switch (_timeOfDay)
            {
                case TimeOfDay.Fire:
                    ActivateFireman();
                    _person.RescuAnimals(_animals);
                    if (new Random().Next(0, 2) == 1)
                    {
                        ActivateRomantic();
                        _person.RescuAnimals(_animals);
                        _presenter.WriteLine("Child will be rescued by Romantic.");
                    }
                    break;
                case TimeOfDay.Day:
                    break;
                case TimeOfDay.Night:
                    break;
            }
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
            List<AnimalTypes> animals = new List<AnimalTypes>();
            _animals.Add(new Animal(animalType.ToString(), animalType));

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
            List<AnimalTypes> animals = animalType.ToList();

            foreach (var animal in animals)
            {
                _animals.Add(new Animal(animal.ToString(), animal));
            }

            switch (_timeOfDay)
            {
                case TimeOfDay.Fire:
                    animals.ForEach(animal =>
                    {
                        switch (animal)
                        {
                            case AnimalTypes.Child:
                                _presenter.WriteLine("Child will be rescued by Romantic.");
                                break;
                        }
                    });
                    _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
                    break;
                case TimeOfDay.Day:
                    break;
                case TimeOfDay.Night:
                    break;
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
