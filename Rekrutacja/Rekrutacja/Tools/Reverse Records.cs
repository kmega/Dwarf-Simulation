using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    public class Reverse_Records
    {

        public string[] Reverse(string[] fileText)
        {
            Array.Reverse(fileText);
            return fileText;
        }
    }
}
