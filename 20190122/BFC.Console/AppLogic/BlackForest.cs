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
		private TimeOfDay _timeOfDay;
		public List<Animal> _animalsOnBranch = new List<Animal>();

		public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
			_timeOfDay = timeOfDay;
			if(timeOfDay == TimeOfDay.Fire)
			{
				ActivateFireman();
				_person.RescuAnimals(_animalsOnBranch);
			}
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
			string name = animalType.ToString();
			switch (_timeOfDay)
			{
				case TimeOfDay.Day:
					switch (animalType)
					{
						case AnimalTypes.Bird:
							_presenter.WriteLine("Bird sit on the Tree.");
							_animalsOnBranch.Add(new Animal(name, animalType));
							break;
						case AnimalTypes.Cat:
							_presenter.WriteLine("Cat doesn't sit on the Tree.");
							break;
						case AnimalTypes.Child:
							_presenter.WriteLine("Child sit on the Tree.");
							_animalsOnBranch.Add(new Animal(name, animalType));
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
							_animalsOnBranch.Add(new Animal(name, animalType));
							break;
						case AnimalTypes.Child:
							_presenter.WriteLine("Child sit on the Tree.");
							_animalsOnBranch.Add(new Animal(name, animalType));
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
			if(_timeOfDay == TimeOfDay.Fire && _animalsOnBranch.Count == 0)
			{
				_presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
			}
			else
			{
				foreach(var animal in animalType)
				{
					SitOnTheTree(animal);
				}
			}
			if (_timeOfDay == TimeOfDay.Fire)
			{
				ActivateFireman();
				_person.RescuAnimals(_animalsOnBranch);
			}
			
        }

        public void ActivateFireman()
        {
            _person = new Fireman(_presenter);
        }

        public void ActivateRomantic()
        {
            _person = new Romantic();
        }
    }
}
