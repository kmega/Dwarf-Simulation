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
        public static void Create(string text)
        {
            File.AppendAllText("result.txt", text);
        }
    }
}
