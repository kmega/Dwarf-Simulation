using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    class TeaCreator
    {
        public List<Tea> Creator(string[] textfile)
        {
            List<Tea> teas = new List<Tea>();
            List<string> tea_data;
            Console.WriteLine();
            for (int i = 2; i < textfile.Count(); i++)
            {
                tea_data = textfile[i].Split(',').ToList<string>();

                    teas.Add(new Tea(tea_data[0], tea_data[1], tea_data[2], tea_data[3], tea_data[4]));

            }
            Console.WriteLine(teas[0]);
            return teas;
        }
    }
}
