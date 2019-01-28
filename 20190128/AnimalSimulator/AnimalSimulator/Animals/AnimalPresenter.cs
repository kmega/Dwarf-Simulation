using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator.Animals
{
    public static class AnimalPresenter
    {
        public static string PresentYourself(IAnimal animal)
        {
            return $"I am {animal.GetType()}, I eat {animal.FoodIEat} and I {animal.WayIMove}";
        }
    }
}
