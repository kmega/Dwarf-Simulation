using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegexTask
{
    class Names_file_in_catalog
    {
        public List<string> names(string url)
        {
            List<string> names_file = new List<string>();

            foreach (string s in Directory.GetFiles(url, "*.md").Select(Path.GetFileName))
            {
                names_file.Add(s);
            }
            return names_file;
        }
    }
}
