using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Order
    {

        public string orderName;
        public List<Ingredients> ingredientsToOrder;
        public string[] otherOrderRequiredToMade;

        public Order(string orderName, List<Ingredients> ingredients)
        {
            this.orderName = orderName;
            this.ingredientsToOrder = ingredients;
        }

        public Order(string orderName, List<Ingredients> ingredients, string[] otherOrder, List<Order> menu)
        {
            this.orderName = orderName;
            this.otherOrderRequiredToMade = otherOrder;
            this.ingredientsToOrder =  AddIngredients(ingredients, menu, otherOrderRequiredToMade);
            


        }

        public List<Ingredients> AddIngredients(List<Ingredients>extendedingredient, List<Order> menu, string[] orderName)
        {

            foreach (var item in orderName)
            {

                foreach (var item2 in menu)
                {
                    if (item2.orderName == item)
                    {
                        extendedingredient.AddRange(item2.ingredientsToOrder);

                    }


                }
            }
            return extendedingredient;
        }

    }
}