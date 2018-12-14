using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Meal
    {
        Dictionary<Enums.Meal, Enums.AllergicBase> MealWithIngredients = 
            new Dictionary<Enums.Meal, Enums.AllergicBase>();

        public Meal(Enums.Meal order)
        {
            MealWithIngredients.Add(order, Enums.AllergicBase.Potatoes);
        }
    }
}
