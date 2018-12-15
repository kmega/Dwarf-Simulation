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

        public Order(string orderName, Ingredients[] ingredients)
        {
            this.orderName = orderName;
            this.ingredientsToOrder = ingredients;
        }
    }
}