using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsWellcome
{
    public class Animal
    {
        public string Type { get; set; }
        public Enums.Meal Meal { get; set; }
        public Enums.Attributes Attribute { get; set; }

        public Animal(string _type, Enums.Meal _meal, Enums.Attributes _attribute)
        {
            Type = _type;
            Meal = _meal;
            Attribute = _attribute;
        }
    }
}
