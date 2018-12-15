using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Klient
    {
        public string name;
        public Ingredients[] allergy;


        public Klient(string klientname, Ingredients[] allergy)
        {
            this.name = klientname;
            this.allergy = allergy;
        }
    }
}