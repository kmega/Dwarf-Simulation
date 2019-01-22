using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountApp
{
    public class Product
    {
        public Product(string type, string name)
        {
            Typ = type;
            Nazwa = name;
        }
        public string Typ;
        public string Nazwa;
    }
}
