using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Customer
    {
        public string name { get; private set; }
        public List<string> allergies { get; private set; }
        public string order { get; set; }
        public Customer(string name,string order,List<string> allergies)
        {
            this.name = name;
            this.order = order;
            this.allergies = allergies;
        }
        

        
    }
}
