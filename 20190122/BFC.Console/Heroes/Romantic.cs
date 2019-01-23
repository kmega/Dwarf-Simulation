using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using BFC.Console.AppLogic;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            if (branch[0].AnimalType == AnimalTypes.Child)
                branch.RemoveAt(0);

        }
    }
}
