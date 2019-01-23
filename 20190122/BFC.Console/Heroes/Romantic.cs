using System;
using System.Collections.Generic;
using System.Linq;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            if (branch.Any(p => p.AnimalType == AnimalTypes.Child))
            {
                branch.Clear();
            }
        }
    }
}