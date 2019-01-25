using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using System.Linq;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;

namespace BFC.Console.Heroes
{

    public class Fireman : Person
    {
        
        private List<AnimalTypes> animalsList;

        public Fireman()
        {

        }
              

        public void RescuAnimals(IList<Animal> branch)
        {
           
            for (int i = 0; i < branch.Count; i++)
            {

                if (branch[i].AnimalType == AnimalTypes.Child
                    || branch[i].AnimalType == AnimalTypes.Cat)
                {
                    branch.RemoveAt(i);
                }
            }
          
        }

       
    }
}

