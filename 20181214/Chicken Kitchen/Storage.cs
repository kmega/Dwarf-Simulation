using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken_Kitchen
{
    class Storage
    {
        public Dictionary<BaseIngredient, int> baseIngredientsInStorage = new Dictionary<BaseIngredient, int>
        {
            {BaseIngredient.ASPARAGUS, 10 },
            {BaseIngredient.CHICKEN, 10 },
            {BaseIngredient.CHOCOLATE, 10 },
            {BaseIngredient.FETA, 10 },
            {BaseIngredient.GARLIC, 10 },
            {BaseIngredient.HONEY, 10 },
            {BaseIngredient.LEMON, 10 },
            {BaseIngredient.MILK, 10 },
            {BaseIngredient.PAPRIKA, 10 },
            {BaseIngredient.PICKLES, 10 },
            {BaseIngredient.POTATOES, 10 },
            {BaseIngredient.RICE, 10 },
            {BaseIngredient.TOMATOES, 10 },
            {BaseIngredient.TUNA, 10 },
            {BaseIngredient.VINEGAR, 10 },
            {BaseIngredient.WATER, 10 }
        };

        public bool CheckAvailabilityBaseIngredientsInStorage(params Ingredient[] ingredients)
        {

            return true;
        }
    }
}
