using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy.Domena
{
    abstract class Product
    {
        public decimal price { get; protected set; }
    }
}
