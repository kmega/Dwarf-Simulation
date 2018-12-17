using System.Collections.Generic;

namespace Chicken_Kitchen
{
    public class Food
    {
        public string foodName;
        public List<Ingredient> ingredients;

        public Food(string foodName, List<Ingredient> ingredients)
        {
            this.foodName = foodName;
            this.ingredients = ingredients;
        }
    }
}