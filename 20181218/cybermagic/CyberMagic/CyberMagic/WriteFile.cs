using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMagic
{
   public  class WriteFile
    {

        public  void writeFile(string toWrite, StreamWriter sr)
        {
            
            sr.Write(toWrite);
            
        }
    }
}
