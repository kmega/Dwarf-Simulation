using System;
using System.Collections.Generic;
using System.Text;

namespace IntroduceAnimal
{
   public class AnimalFactory
    {
        public Animal CreateAnimal(AnimalTypes name)
        {
            string animalName = "";
            string movement = "";
            string eating = "";

            switch (name)
            {
                case AnimalTypes.Bear:
                     animalName = "Bear";
                     movement = "walking";
                     eating = "omnivorous";

                    break;
                case AnimalTypes.Pelican:
                    animalName = "Pelican";
                     movement ="flying";
                     eating = "ichthyophagous";
                    break;
                case AnimalTypes.Vegetarian:
                     animalName = "Vegetarian";
                     movement = "swimming";
                     eating = "herbivorous";
                    break;
                case AnimalTypes.KillerWhale:
                     animalName = "KillerWhale";
                     movement = "swimming";
                     eating = "carnivorous";
                    break;

            }
            Animal newAnimal = new Animal();
            newAnimal.SetName(animalName);
            newAnimal.SetEatingStyle(eating);
            newAnimal.SetMovementStyle(movement);

            return newAnimal;

        }
       
    }
}
