using System;
using System.Collections.Generic;
using System.Linq;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{

    public class Fireman: Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            foreach (Animal animal in branch)
            {
                if (!animal.ToString().Contains("Bird"))
                {
                       branch.Clear();
                   
                } break;
            }
                

        }
    }
}
