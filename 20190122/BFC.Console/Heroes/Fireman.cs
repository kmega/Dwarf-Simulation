using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using System.Linq;

namespace BFC.Console.Heroes
{

    public class Fireman: Person
    {
		private IOutputWritter _presenter;
		public Fireman()
		{
			_presenter = new WindowsConsole();
		}
		public Fireman(IOutputWritter presenter)
		{
			_presenter = presenter ?? new WindowsConsole();
		}

		public void RescuAnimals(IList<Animal> branch)
		{
			if (branch.Where(x => x.AnimalType == AnimalTypes.Cat).Any()
				|| branch.Where(x => x.AnimalType == AnimalTypes.Child).Any())
			{
				_presenter.WriteLine("Child, Cat will be rescued by Fireman.");
			}
			else
			{
				_presenter.WriteLine("Fireman generated alarm sound.");
				_presenter.WriteLine("Nobody will be rescued by Fireman.");
			}
			
			for (int i = 0; i < branch.Count; i++)
			{
				if (branch[i].AnimalType != AnimalTypes.Bird)
				{
					branch.RemoveAt(i);
					i = -1;
				} 
			}
        }
    }
}
 