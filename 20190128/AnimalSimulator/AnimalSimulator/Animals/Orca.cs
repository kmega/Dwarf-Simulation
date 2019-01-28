using AnimalSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator.Animals
{
    public class Orca :IAnimal
    {
        public MovingMethod WayIMove { get; set; }
        public TypeOfFoodConsumption FoodIEat { get; set; }
        public Orca()
        {
            WayIMove = MovingMethod.Swim;
            FoodIEat = TypeOfFoodConsumption.Meat;
        }
    }
}
