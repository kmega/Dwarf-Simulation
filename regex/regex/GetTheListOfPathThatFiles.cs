using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace regex
{
    public class GetTheListOfPathThatFiles
    {
        public List<string> ListOfPathThatFiles(string path)
        {
            List<string> name = Directory.GetFiles(path).ToList<string>(); // Lista ścieżek wszystkich  
            return name;
        }
    }
}