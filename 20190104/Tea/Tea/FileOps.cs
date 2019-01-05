using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
   public class FileOps
    {

        

        public List<string> ReadTeaFile(string path)
        {
            List<string> teafile = new List<string>();
            string line;
            StreamReader sr = new StreamReader(path);

            while ((line = sr.ReadLine()) != null)
            {
                teafile.Add(line);
            }
            return teafile;
           

        }

        public List<string> ReadTeaFile(string path, string encoding)
        {
            List<string> teafile = new List<string>();
            string line;
            StreamReader sr = new StreamReader(path,Encoding.GetEncoding(encoding));

            while ((line = sr.ReadLine()) != null)
            {
                teafile.Add(line);
            }
            return teafile;


        }


    }
}
