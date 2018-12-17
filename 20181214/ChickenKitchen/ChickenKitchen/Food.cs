using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Food
    {
        string name;
        List<string> ingredients;
        public Food(string name, List<string> ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;
        }
    }
}
