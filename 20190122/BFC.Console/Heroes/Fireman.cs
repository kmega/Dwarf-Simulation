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
            //throw new NotImplementedException();
            List<Animal> rescuBranch = new List<Animal>();
            foreach (var animal in branch)
            {
                rescuBranch.Add(animal);
            }

            rescuBranch.ForEach(animal =>
            {
                if (animal.AnimalType != AnimalTypes.Bird)
                {
                    branch.Remove(animal);
                }
            });
        }
    }
}
