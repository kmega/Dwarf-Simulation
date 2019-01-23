using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using System.Linq;

namespace BFC.Console.Heroes
{

    public class Fireman: Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            List<Animal> animalsToDelete = new List<Animal>();

            foreach (var animal in branch)
            {
                if (animal.AnimalType == AnimalTypes.Child || animal.AnimalType == AnimalTypes.Cat)
                    animalsToDelete.Add(animal);
            }

            foreach (var animal in animalsToDelete)
            {
                branch.Remove(animal);
            }
        }
    }
}
