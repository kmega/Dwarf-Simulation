using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CyberMagic
{
    class StringReturner
    {

        public string FileText(string url)
        {
            string result = File.ReadAllText(url);
            return result;
        }
    }
}
