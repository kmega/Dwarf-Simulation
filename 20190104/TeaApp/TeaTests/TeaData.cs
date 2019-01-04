using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaApp;

namespace TeaTests
{
    public static class TeaData
    {
        public static List<string> Records()
        {
            return File.ReadAllLines("tea-data.txt").ToList();
        }
        public static List<string> RawTeas()
        {
            return File.ReadAllLines("rawTeas.txt").ToList();
        }
        public static List<string> OrderedTeaTypes()
        {
            return new List<string>()
            {
                "czarna",
                "czarna",
                "napar",
                "napar",
                "owocowa",
                "zielona",
                "zielona"
            };
        }
        public static List<Tea> fakeTeaList()
        {
            return new List<Tea>()
            {
                new Tea("Mięta", "napar", 96, 5)
            };
        }
    }
}
