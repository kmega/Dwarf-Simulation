using System.Collections.Generic;

namespace Chicken_Kitchen
{
    public class Food
    {
        public string FoodName { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Food(string foodName, List<Ingredient> ingredients)
        {
            FoodName = foodName;
            Ingredients = ingredients;
        }
    }
}