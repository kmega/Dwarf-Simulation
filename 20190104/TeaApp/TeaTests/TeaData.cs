using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTests
{
    public static class TeaData
    {
        public static List<string> Records()
        {
            return File.ReadAllLines("tea-data.txt").ToList();
        }
    }
}
