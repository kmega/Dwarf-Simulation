using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Pelican : IAnimal
    {
        public string Introduce()
        {
            return $"I'am the Pelican and I {AnimalType.FLY}, eat {AnimalFood.FISH}";
        }
    }
}