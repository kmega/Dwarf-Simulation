using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class Sort
    {

        public string[] sort_letter_list(string[] table)
        {
            Array.Sort(table, StringComparer.InvariantCulture);
            return table;
        }
    }
}
