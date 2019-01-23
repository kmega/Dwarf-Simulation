using System;
using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            foreach (Animal animal in branch)
            {
                if (animal.ToString().Contains("Child"))
                {
                    branch.Clear();

                }
                break;
            }
        }
    }
}
