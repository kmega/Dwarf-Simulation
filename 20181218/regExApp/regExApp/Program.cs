using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace regExApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = @"\cybermagic\karty-postaci\1807-fryderyk-komciur.md";

            string[] fryderyk = File.ReadAllLines(path);

        }
    }
}
