using AnimalSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator.Animals
{
    class Pelican : IAnimal
    {
        public MovingMethod WayIMove { get; set; }
        public TypeOfFoodConsumption FoodIEat { get; set; }
        public Pelican()
        {
            WayIMove = MovingMethod.Fly;
            FoodIEat = TypeOfFoodConsumption.Fish;
        }
    }
}
