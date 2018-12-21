using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMagic
{
  public   class ReadFile
    {

        public string readFile(string path)
        {

            string txt = File.ReadAllText(path);

            return txt;
        }


        public  List<string> readManyFiles(string path)
        {

            List<string> files = Directory.GetFiles(path).ToList();
            List<string> alltext = new List<string>();


            foreach (string temp in files)
            {
                alltext.Add(readFile(temp));
            }
            return alltext;

        }
    }
}
