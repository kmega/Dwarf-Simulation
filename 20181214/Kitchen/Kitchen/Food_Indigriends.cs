using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    class Food_Indigriends
    {

        public static Dictionary<string, string> food_indigriends;

        public static string List_Indigriends(string food)
        {
            food_indigriends = new Dictionary<string, string>();
            food_indigriends.Add(Food.Fries.ToString(), Ingridents.Potatoes.ToString());



            return food_indigriends[food].ToString();
        }
    }
}
