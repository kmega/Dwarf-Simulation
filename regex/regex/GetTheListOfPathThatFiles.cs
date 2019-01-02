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
            
            //Usunięcie elementu "template"
            for (int i = 0; i < name.Count; i++)
            {
                if (name[i].Contains("template"))
                {
                name.RemoveAt(i);
                }
            }
            return name;
        }
    }
}