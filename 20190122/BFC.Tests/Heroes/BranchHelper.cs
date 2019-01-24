using System.Collections.Generic;
using System.Linq;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    internal class BranchHelper
    {
        internal static IList<Animal> PutAnimalOnBranch(AnimalTypes animalType)
        {
            return new List<Animal>()
            {
                new Animal(animalType.ToString(), animalType)
            };
        }
        internal static IList<Animal> PutAnimalsOnBranch(AnimalTypes[] animalTypes)
        {
            IList<Animal> animals = new List<Animal>();
            animalTypes.ToList().ForEach(a => animals.Add(new Animal(a.ToString(), a)));
            return animals;
        }
    }
}