using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Orca : IAnimal
    {
        public string Introduce()
        {
            return $"I'am the Orca and I {AnimalType.SWIM}, eat {AnimalFood.MEAT}";
        }
    }
}