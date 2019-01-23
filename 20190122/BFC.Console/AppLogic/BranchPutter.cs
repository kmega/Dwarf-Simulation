using BFC.Console.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BFC.Console.AppLogic
{
    public class BranchPutter
    {
        public List<Animal> PutAnimalOnBranch(AnimalTypes animalType)
        {
            return new List<Animal>()
            {
                new Animal(animalType.ToString(), animalType)
            };
        }
        public List<Animal> PutAnimalsOnBranch(AnimalTypes[] animalTypes)
        {
            List<Animal> animals = new List<Animal>();
            animalTypes.ToList().ForEach(a => animals.Add(new Animal(a.ToString(), a)));
            return animals;

        }
    }
}
