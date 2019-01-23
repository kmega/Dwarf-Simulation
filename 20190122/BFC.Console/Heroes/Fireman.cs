using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using BFC.Console.AppLogic;

namespace BFC.Console.Heroes
{

    public class Fireman: Person
    {
        public void RescuAnimals(IList<Animal> branch)
        {
            for (int i = 0; i < branch.Count; i++)
            {
                if (branch[i].AnimalType != AnimalTypes.Bird)
                {
                    branch.RemoveAt(i);
                    i = -1;
                }
                    
            }
            
        }
    }
}
