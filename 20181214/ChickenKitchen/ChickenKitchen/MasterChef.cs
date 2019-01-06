using ChickenKitchen.RestaurantDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
   public class MasterChef
    {

        public string GiveAMeal (Order ordereddinner, Dictionary<Ingredients, int> store, Client klient)
        {
            string result = "";
            if (CheckIngredients(klient, ordereddinner))
            {
                 result = "This meal will kill you";
            }

            else {


                Dictionary<Ingredients, int> usedingredients = PrepareMeal(ordereddinner, store);
                var output = usedingredients.Select(x => x.Key + " x" + x.Value + ",");
                 result = "We prepared "+  ordereddinner.orderName +" for " + klient.name +
                    " and it cost:\n" + String.Join("\n ", output);
                         

            }
            return result;

        }


        public Boolean CheckIngredients(Client klient, Order dinner)
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

        public Dictionary<Ingredients,int> PrepareMeal(Order dinner, Dictionary<Ingredients, int> store)
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
            return usedingredients;
               
            }
        }
    }

