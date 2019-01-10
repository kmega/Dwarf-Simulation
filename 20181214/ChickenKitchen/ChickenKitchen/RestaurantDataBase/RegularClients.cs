using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen.RestaurantDataBase
{
    public class RegularClients
    {

       public List<Client> regularclients;

       public RegularClients()
        {

            regularclients = new List<Client>()
            {
                new Client("Julie Mirage", new Ingredients[] {Ingredients.Soy}),
                new Client ("Elon Carousel",new Ingredients[] {Ingredients.Vinegar, Ingredients.Olive }),
                 new Client("Adam Smith", new Ingredients[] {}),
                  new Client("Barbara Smith", new Ingredients[] {Ingredients.Chocolate}),
                   new Client("Christin Donnovan", new Ingredients[] {Ingredients.Paprika}),
                    new Client("Bernard Unfortunate", new Ingredients[] {Ingredients.Potatoes}),

                    
            };

        }
    }
}
