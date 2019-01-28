using System;
using System.Collections.Generic;
using System.Text;

namespace Animals_information
{
    public class CreateAnimalData
    {
        List<AnimalObject> animalObjectsList = new List<AnimalObject>();
        public void AnimalObject(AnimalObject animalObject)
        {
            List<AnimalObject> animalObjectsList = new List<AnimalObject>();
            animalObjectsList.Add(animalObject);
        }

        public List<AnimalObject> Write()
        {
            return animalObjectsList;
        }
    }
}
