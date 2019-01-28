using AnimalSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator.Animals
{
    public class VegeMan :IAnimal
    {
        public MovingMethod WayIMove { get; set; }
        public TypeOfFoodConsumption FoodIEat { get; set; }
        public VegeMan()
        {
            WayIMove = MovingMethod.Walk;
            FoodIEat = TypeOfFoodConsumption.Plants;
        }
    }
}
