using System;
using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        private List<Animal> RescuedAnimals = new List<Animal>();

        public void RescuAnimals(IList<Animal> branch)
        {
            List<Animal> rescuBranch = new List<Animal>();
            foreach (var animal in branch)
            {
                rescuBranch.Add(animal);
            }

            rescuBranch.ForEach(animal =>
            {
                if (animal.AnimalType.Equals(AnimalTypes.Child))
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

            return animalList.Remove(animalList.Length - 2) + "will be rescued by Romantic.";
        }
    }
}
