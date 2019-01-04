using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    class Tea
    {
         string Name { get; set; }
         string Type { get; set; }
         string Temp { get; set; }
         string Time { get; set; }
         string Special { get; set; }

        public Tea(string name, string type, string temp, string time)
        {
            Name = name;
            Type = type;
            Temp = temp;
            Time = time;
        }

        public Tea(string name, string type, string temp, string time, string special)
        {
            Name = name;
            Type = type;
            Temp = temp;
            Time = time;
            Special = special;
        }

        public override string ToString()
        {
            return $"{Name}, {Type}, {Temp}, {Time}, {Special}";
        }
    }
}
