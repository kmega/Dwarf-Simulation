using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task5
{
    class ConfigFileReader
    {
        public List<string> ConfigReader(string path)
        {
            string commands = File.ReadAllText(path);
            return commands.Split(',').ToList();
        }
    }
}