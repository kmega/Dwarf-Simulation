using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using System.Linq;

namespace BFC.Console.Heroes
{

    public class Fireman: Person
    {
        private List<Animal> RescuedAnimals = new List<Animal>();

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
                    RescuedAnimals.Add(animal);
                    branch.Remove(animal);
                }
            });
        }

        public string ListOfRescuedAnimals()
        {
            string animalList = "";
            RescuedAnimals.ForEach(animal =>
            {
                animalList += animal + ", ";
            });

            return animalList.Remove(animalList.Length - 2) + " will be rescued by Fireman.";
        }
    }
}
