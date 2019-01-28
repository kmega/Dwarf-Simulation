using AnimalSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator.Animals
{
    public static class AnimalFactory
    {
        public static IAnimal Create(AnimalType animalType)
        {
            switch(animalType)
            {
                case AnimalType.Orca:
                    return new Orca();
                case AnimalType.Bear:
                    return new Bear();
                case AnimalType.Pelican:
                    return new Pelican();
                case AnimalType.VegeMan:
                    return new VegeMan();
                default:
                    return null;
            }
        }
    }
}
