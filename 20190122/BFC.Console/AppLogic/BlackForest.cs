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
		public List<AnimalTypes> _animalsOnBranch = new List<AnimalTypes>();

		public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay(TimeOfDay timeOfDay)
        {
			_timeOfDay = timeOfDay;
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {
			switch (_timeOfDay)
			{
				case TimeOfDay.Day:
					switch (animalType)
					{
						case AnimalTypes.Bird:
							_presenter.WriteLine("Bird sit on the Tree.");
							_animalsOnBranch.Add(animalType);
							break;
						case AnimalTypes.Cat:
							_presenter.WriteLine("Cat doesn't sit on the Tree.");
							break;
						case AnimalTypes.Child:
							_presenter.WriteLine("Child sit on the Tree.");
							_animalsOnBranch.Add(animalType);
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
							_animalsOnBranch.Add(animalType);
							break;
						case AnimalTypes.Child:
							_presenter.WriteLine("Child sit on the Tree.");
							_animalsOnBranch.Add(animalType);
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
