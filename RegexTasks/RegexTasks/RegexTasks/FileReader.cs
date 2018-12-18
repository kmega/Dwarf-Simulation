using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTasks
{
    class FileReader
    {
        public string[] fullstringsfromfile;

        public string[] Read_File()
        {
            //string path = "..\\..\\..\\..\\..\\cybermagic\\karty-postaci\\1807-fryderyk-komciur.md";

            // Read the stream to a string, and write the string to the console.

            fullstringsfromfile = File.ReadAllLines(@"..\\..\\..\\..\\..\\20181218\\cybermagic\\karty-postaci\\1807-fryderyk-komciur.md");


            return fullstringsfromfile;
        }
    }
}
