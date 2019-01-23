using System;
using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            var temp = branch;

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].AnimalType == AnimalTypes.Child)
                {
                    branch.Remove(temp[i]);
                }
            }
        }
    }
}
