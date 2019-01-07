using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableSorting
{
    public class EvenStringFactory
    {
        public EvenStringFactory()
        {
            EvenLetters = new List<string>();
            NotEvenLetters = new List<string>();
        }
        public List<string>EvenLetters { get; set; }
        public List<string> NotEvenLetters{ get; set; }
    }
}
