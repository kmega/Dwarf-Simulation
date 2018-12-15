using System.Collections.Generic;

namespace Chicken_Kitchen
{
    public class Ingredient
    {
        public string Name { get; set; }
        public List<BaseIngredient> BaseIngrediens { get; set; }

        public Ingredient(string name, List<BaseIngredient> baseIngredients)
        {
            Name = name;
            BaseIngrediens = baseIngredients;
        }
    }
}