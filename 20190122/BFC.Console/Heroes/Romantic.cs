using System;
using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
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
                if (animal.AnimalType.Equals(AnimalTypes.Child))
                {
                    branch.Remove(animal);
                }
            });
        }
    }
}
