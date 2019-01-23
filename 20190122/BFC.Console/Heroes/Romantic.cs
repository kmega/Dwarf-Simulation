using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using System.Linq;
using BFC.Console.Presentation;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
		private IOutputWritter _presenter;
		public Romantic()
		{
			_presenter = new WindowsConsole();
		}
		public Romantic(IOutputWritter presenter)
		{
			_presenter = presenter ?? new WindowsConsole();
		}

		public void RescuAnimals(IList<Animal> branch)
        {
			if(branch.Where(x => x.AnimalType == AnimalTypes.Child).Any())
			{
				_presenter.WriteLine("Child will be rescued by Romantic.");
			} else
			{
				_presenter.WriteLine("Nobody will be rescued by Romantic.");
			}
			for(int i = 0; i < branch.Count; i++)
			{
				if (branch[i].AnimalType == AnimalTypes.Child)
				{
					branch.RemoveAt(i);
					i = -1;
				}
			}
           
        }
    }
}
