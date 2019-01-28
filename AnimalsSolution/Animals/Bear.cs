using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Bear : IAnimal
    {
        public string Introduce()
        {
            return $"I'am the Bear and I {AnimalType.WALK}, eat {AnimalFood.MEAT}";
        }
    }
}