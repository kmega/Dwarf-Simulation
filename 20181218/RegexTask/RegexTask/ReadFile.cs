using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegexTask
{
    class ReadFile
    {
        public string Check_Fryderyk_Komciura(string URL)
        {
            string file = File.ReadAllText(URL);
            //Console.WriteLine(file);
            //Console.ReadKey();
            return file;
        }
        
    }
}
