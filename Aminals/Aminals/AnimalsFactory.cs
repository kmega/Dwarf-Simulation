using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminals
{
	public class AnimalsFactory
	{
		public IAnimal CreateAnimal(Animals animal)
		{
			if(animal == Animals.Bear)
			{
				return new Bear();
			} else if (animal == Animals.Homo)
			{
				return new Wege();
			} else if (animal == Animals.Orca)
			{
				return new Orca();
			} else if (animal == Animals.Pelican)
			{
				return new Pelican();
			}
			return null;
		}
	}
}
