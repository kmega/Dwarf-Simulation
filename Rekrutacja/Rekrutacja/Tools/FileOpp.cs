using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rekrutacja
{
    public class FileOpp
    {
        public string[] FileText(string url)
        {
            return File.ReadAllLines(url);
        }

        public void Saver( string file_name, string[] text)
        {
            File.WriteAllLines(file_name, text);
            Console.WriteLine("Save the file");
        }
    }
}
