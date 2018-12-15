using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken_Kitchen
{
    class Restaurant
    {
        public List<Client> clients = new List<Client> {
            new Client("Julie", "Mirage", new List<Allergy>() { Allergy.SOY }),
            new Client("Elon", "Carousel", new List<Allergy>() { Allergy.VINEGAR, Allergy.OLIVES }),
            new Client("Adam", "Smith", new List<Allergy>() { Allergy.LACK }),
            new Client("Barbara", "Smith", new List<Allergy>() { Allergy.CHOCOLATE }),
            new Client("Christian", "Donnovan", new List<Allergy>() { Allergy.PAPRIKA }),
            new Client("Bernard", "Unfortunate", new List<Allergy>() { Allergy.POTATOES })
        };

       public void ShowClientsList()
        {
            Console.WriteLine();
            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine("Client number: {0}, First Name: {1}, Last Name: {2}", i+1, clients[i].FirstName, clients[i].LastName);
            }
        }

        public Dictionary<BaseIngredient, int> baseIngredientsStorage = new Dictionary<BaseIngredient, int>
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

        public List<Food> foods = new List<Food> {
           new Food("Fries", new List<Ingredient>() {new Ingredient("Potatos", new List<BaseIngredient>() {BaseIngredient.TOMATOES })})
        };


        public void ShowFoodList()
        {
            Console.WriteLine();
            for (int i = 0; i < foods.Count; i++)
            {
                Console.WriteLine("Number of food: {0}, Name: {1}", i + 1, foods[i].FoodName);
            }
        }




        public void ServeDish(Client client, Food food)
        {

        }

    }
}
