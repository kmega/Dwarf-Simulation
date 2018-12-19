using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegexTask
{
    class ReadFile
    {
        public string Return_file(string URL)
        {
            string file = File.ReadAllText(URL);
            return file;
        }
        
    }
}
