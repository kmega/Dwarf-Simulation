using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace regExApp
{
    class Program
    {

        static void Main(string[] args)
        {
            
            string path = "1807-fryderyk-komciur.md";

            string[] fryderyk = File.ReadAllLines(path);

            Console.WriteLine(fryderyk);

           /* Regex readFile = new Regex(@"\((\d\d) min.*\");

            MatchCollection timeFromFile;

            for (int i=0; i<fryderyk.Length;i++)
            {
                timeFromFile = readFile.Matches(fryderyk[i]);

                if (timeFromFile != null) { Console.WriteLine(timeFromFile); }
            }
            */
            Console.ReadKey();



        }
    }
}
