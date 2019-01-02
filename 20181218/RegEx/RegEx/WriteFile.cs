using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RegEx
{
    public class WriteFile
    {
        public void WriteResultToFile(string fileResultPath, string result)
        {
            File.WriteAllText(fileResultPath, result);
        }
    }
}
