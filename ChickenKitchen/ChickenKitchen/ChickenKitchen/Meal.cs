using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Meal
    {
       public Dictionary<Enums.Meal, List<Enums.AllergicBase>> MealWithBasicIngredients =
            new Dictionary<Enums.Meal, List<Enums.AllergicBase>>()
        {
                //Contains definitions all Salad
                #region                 Salads
                {Enums.Meal.Diamond_Salad,
                    new List<Enums.AllergicBase>
                    { Enums.AllergicBase.Tomatoes, Enums.AllergicBase.Pickles, Enums.AllergicBase.Feta } },

                {Enums.Meal.Ruby_Salad,
                new List<Enums.AllergicBase>
                {Enums.AllergicBase.Tomatoes, Enums.AllergicBase.Vinegar}},
#endregion

                //Contains definitions all Sauces
                #region                Sauces

                {Enums.Meal.Youth_Sauce,
                new List<Enums.AllergicBase>
                {Enums.AllergicBase.Asparagus, Enums.AllergicBase.Milk, Enums.AllergicBase.Honey }},

                {Enums.Meal.Spicy_Sauce,
                new List<Enums.AllergicBase>
                {Enums.AllergicBase.Paprika, Enums.AllergicBase.Garlic, Enums.AllergicBase.Water }},

                {Enums.Meal.Omega_Sauce,
                new List<Enums.AllergicBase>
                {Enums.AllergicBase.Lemon, Enums.AllergicBase.Water } },

                #endregion

                #region Fries
                {Enums.Meal.Fries,
                new List<Enums.AllergicBase>
                {Enums.AllergicBase.Potatoes}},
                #endregion

                #region Smashed Potatoes
                {Enums.Meal.Smashed_Potatoes,
                new List<Enums.AllergicBase>
                {Enums.AllergicBase.Potatoes} }
                #endregion

            };

        public Enums.Meal order_key { get; set; }




        public Meal(Enums.Meal order)
        {
            order_key = order;
        }
    }
}
