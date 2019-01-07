using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableSorting
{
    public class ListFactory
    {
        public ListFactory()
        {
            Letters = new List<string>();
            Numbers = new List<int>();
        }
        public List<string> Letters{ get; set; }
        public List<int> Numbers{ get; set; }
    }
}
