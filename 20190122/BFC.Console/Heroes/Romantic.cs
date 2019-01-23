using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using System.Linq;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
		private IOutputWritter _presenter;
		public Romantic
		public void RescuAnimals(IList<Animal> branch)
        {
			if(branch.Where(x => x.AnimalType == AnimalTypes.Child).Any())
			{

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
