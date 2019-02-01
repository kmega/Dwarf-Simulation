using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
    public class Rekord
    {

        public Rekord(string name, string path, int depth)
        {
            _path = path;
            _name = name;
            _depth = depth;
        }
      public string _path;
      public string _name;
      public int _depth;

        
    }
}
