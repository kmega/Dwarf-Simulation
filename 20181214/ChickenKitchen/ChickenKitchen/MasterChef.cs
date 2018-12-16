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
                Dictionary<Ingredients,int> usedingredients = new Dictionary<Ingredients,int>();
                foreach (var item in dinner.ingredientsToOrder)
                {

                    if (store.ContainsKey(item))
                    {

                        store[item] -= 1;
                        if (!(usedingredients.ContainsKey(item)))
                        {
                            usedingredients.Add(item, 1);
                        }

                        else
                        {
                            usedingredients[item] += 1;
                        }
                    }

                }
                var output = usedingredients.Select(x => x.Key + " x" + x.Value+",");
                Console.WriteLine("We prepared {0} for {1} and it cost:\n {2}",
                           dinner.orderName, klient.name, String.Join("\n ", output));
            }
        }
    }
}
