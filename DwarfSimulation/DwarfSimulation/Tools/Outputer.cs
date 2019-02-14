using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Outputer
    {
        internal void Display(List<string> output)
        {
            output.ForEach(i => Console.WriteLine("{0}\t", i));
        }
    }
}
