using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class Marge
    {
        public string[] marge_list(string[] a, string[] b, string[] c)
        {
            List<string> reslut = new List<string>();

            reslut = a.ToList();
            reslut.AddRange(b.ToList());
            reslut.AddRange(c.ToList());

            return reslut.ToArray();
        }
    }
}
