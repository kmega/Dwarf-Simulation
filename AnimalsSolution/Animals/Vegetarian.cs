using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Vegetarian : IAnimal
    {
        public string Introduce()
        {
            return $"I'am the Vegetarina and I {AnimalType.WALK}, eat {AnimalFood.WEGE}";
        }
    }
}