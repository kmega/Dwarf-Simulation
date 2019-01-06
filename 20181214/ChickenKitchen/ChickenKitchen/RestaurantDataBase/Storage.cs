using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen.RestaurantDataBase
{
   public  class Storage
    {

        public Dictionary<Ingredients, int> store;

        public Storage() {
        store = new Dictionary<Ingredients, int>();

            foreach (Ingredients item in Enum.GetValues(typeof(Ingredients)))
            {
                store.Add(item, 10);
            }
        }

}
}
