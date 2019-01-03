using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMagic
{
    public static class TextFileManager
    {
        internal static string ReadFile(string fileName)
        {
            string text = File.ReadAllText(fileName);
            return text;

        }
        public static void WriteResults(string[] toSave)
        {
            File.AppendAllLines("result.txt", toSave);
        }

    }
}
