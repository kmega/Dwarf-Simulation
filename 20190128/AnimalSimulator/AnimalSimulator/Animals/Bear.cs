using System;
using System.Collections.Generic;
using System.Text;
using AnimalSimulator.Enums;

namespace AnimalSimulator.Animals
{
    public class Bear : IAnimal
    {
        public MovingMethod WayIMove { get; set ; }
        public TypeOfFoodConsumption FoodIEat { get; set; }

        public Bear()
        {
            WayIMove = MovingMethod.Walk;
            FoodIEat = TypeOfFoodConsumption.Everything;
        }
    }
}
