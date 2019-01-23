using System;
using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            List<Animal> animalsToDelete = new List<Animal>();

            foreach (var animal in branch)
            {
                if (animal.AnimalType == AnimalTypes.Child)
                    animalsToDelete.Add(animal);
            }

            foreach (var animal in animalsToDelete)
            {
                branch.Remove(animal);
            }
        }
    }
}
