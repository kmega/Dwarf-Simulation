using System.Collections.Generic;
using System.Linq;
using System;

namespace pkozlowski
{
    class Program
    {
        const string resultFile = "wynik.txt";

        static void Main(string[] args)
        {
            Task3.run(resultFile);
            Task4.run(resultFile);
        }
    }
}
