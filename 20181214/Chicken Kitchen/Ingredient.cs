using System.Collections.Generic;

namespace Chicken_Kitchen
{
    public class Ingredient
    {
        public string name;
        public List<BaseIngredient> baseIngrediens;

        public Ingredient(string name, List<BaseIngredient> baseIngredients)
        {
            this.name = name;
            this.baseIngrediens = baseIngredients;
        }
    }
}