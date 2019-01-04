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
       public  string type;
       public  int temperature;
       public  int time;

        public TeaObj (string Name, string Type, int Temperature, int Time)
        {
            this.name = Name;
            this.type = Type;
            this.temperature = Temperature;
           this. time = Time;
        }

        public override string ToString()
        {
            return name + ", " + type + ", " + temperature + ", " + time;
        }

    }
}
