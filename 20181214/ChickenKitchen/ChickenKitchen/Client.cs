using ChickenKitchen.RestaurantDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    public class Client
    {
        public string name;
        public Ingredients[] allergy;


        public Client(string klientname, Ingredients[] allergy)
        {
            this.name = klientname;
            this.allergy = allergy;
        }
    }
}