using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class TextFileCreator
    {
        public static void CreateOrAppend(string file, string value)
        {
            File.AppendAllText(file, value);
            File.AppendAllText(file, "\n");
        }

    }
}
