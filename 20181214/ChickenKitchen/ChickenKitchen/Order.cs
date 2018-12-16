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
        public Ingredients[] ingredientsToOrder;
        public string otherOrderRequiredToMade;

        public Order(string orderName, Ingredients[] ingredients)
        {
            this.orderName = orderName;
            this.ingredientsToOrder = ingredients;
        }

        public Order(string orderName, Ingredients[] ingredients, string otherOrder, List<Order> menu)
        {
            this.orderName = orderName;
            this.otherOrderRequiredToMade = otherOrder;
            this.ingredientsToOrder =  AddIngredients(ingredients, menu, otherOrderRequiredToMade);
            


        }

        public Ingredients[] AddIngredients(Ingredients[] extendedingredient, List<Order> menu, string orderName)
        {

            
            foreach (var item in menu)
            {
                if (item.orderName==orderName)
                {
                    Array.Resize(ref extendedingredient, extendedingredient.Length + item.ingredientsToOrder.Length);
                       Array.Copy(item.ingredientsToOrder, extendedingredient, item.ingredientsToOrder.Length);
                    
                }
                
               
            }
            return extendedingredient;
        }

    }
}