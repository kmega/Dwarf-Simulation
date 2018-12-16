using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class MasterChef
    {
        public Boolean CheckIngredients(Klient klient, Order dinner)
        {
            if (dinner.ingredientsToOrder.Intersect(klient.allergy).Any())
                
            {
                return true;
            }
            
           
            else
            {
                return false;
            }
        }

        public void PrepareMeal(Order dinner, Dictionary<Ingredients, int> store, Klient klient)
        {

            if (CheckIngredients(klient, dinner))
            {
                Console.WriteLine("This meal will kill you");
            }

            else
            {
                List<Ingredients> usedingredients = new List<Ingredients>();
                foreach (var item in dinner.ingredientsToOrder)
                {

                    if (store.ContainsKey(item))
                    {

                        store[item] -= 1;
                        usedingredients.Add(item);

                    }

                }
                Console.WriteLine("We prepared {0} for {1} and it cost (x1):\n {2}",
                           dinner.orderName, klient.name, String.Join(",\n ", usedingredients));
            }
        }
    }
}
