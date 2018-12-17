using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken_Kitchen
{
    class Allergy_Ingredients
    {
        public IDictionary<Customer, List<Ingredient>> _dictionary_allergy_ingredients;
        public List<Ingredient> _list_allergy_ingredients;

        public Allergy_Ingredients()
        {
            _dictionary_allergy_ingredients = new Dictionary<Customer, List<Ingredient>>();

            _dictionary_allergy_ingredients.Add(Customer.Adam_Smith, new List<Ingredient>() {});
            _dictionary_allergy_ingredients.Add(Customer.Julie_Mirage, new List<Ingredient>() {Ingredient.Soy});
        }

        public List<Ingredient> list_of_allergy_ingredients(Customer customer)
        {
            Console.WriteLine("Allergy ingredient");
            foreach (var item in _dictionary_allergy_ingredients[customer])
            {
                Console.WriteLine(item);
            }

            return _dictionary_allergy_ingredients[customer];
        }
    }
}
