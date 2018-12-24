using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task5
{
    class ConfigFileReader
    {
        public string ConfigReader(string path)
        {
            return File.ReadAllText(path);
        }
    }
}