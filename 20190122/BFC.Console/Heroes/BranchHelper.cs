using System.Collections.Generic;
using System.Linq;
using BFC.Console.Animals;

namespace BFC.Tests.Heroes
{
    public static class BranchHelper
    {
        public static IList<Animal> PutAnimalOnBranch(AnimalTypes animalType)
        {
            return new List<Animal>()
            {
                new Animal(animalType.ToString(), animalType)
            };
        }
        public static IList<Animal> PutAnimalsOnBranch(AnimalTypes[] animalTypes)
        {
            IList<Animal> animals = new List<Animal>();
            animalTypes.ToList().ForEach(a => animals.Add(new Animal(a.ToString(), a)));
            return animals;
        }
    }
}