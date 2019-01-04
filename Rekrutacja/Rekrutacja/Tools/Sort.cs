using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Tools
{
    class Sort
    {

        public List<Tea> Sorter(List<Tea> teas)
        {
            List<Tea> SortedList = teas.OrderBy(o => o.).ToList();
        }
    }
}
