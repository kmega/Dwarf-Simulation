using AnimalSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator.Animals
{
    public interface IAnimal
    {
        MovingMethod WayIMove { get; set; }
        TypeOfFoodConsumption FoodIEat { get; set; }
    }
}
