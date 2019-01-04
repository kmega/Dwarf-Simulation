using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
    public class ReadingFile
    {

        public List<string> teas;

        public ReadingFile(string path)
        {
            teas = ReadTea(path);
        }

        public List<string> ReadTea(string path)
        {
        StreamReader sr = new StreamReader(path);
            var temptealist = new List<string>();
            string line="";
            while ((line = sr.ReadLine()) != null)
            {
                
              
               
                    temptealist.Add(line);
                
            };

            return temptealist;
        }
    }
}
