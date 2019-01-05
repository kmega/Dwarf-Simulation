using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
   public class TeaObj
    {
        public string name;
       public string type;
        public double  temp;
        public double time;

        public TeaObj(string Name, string Type, double Temp, double Time)
        {
            name = Name;
            type = Type;
            temp = Temp;
            time = Time;
        }

        public override string ToString()
        {
            string delimeter = ", ";
            return name + delimeter + type + delimeter  + temp + delimeter + time;
        }

    }
}
