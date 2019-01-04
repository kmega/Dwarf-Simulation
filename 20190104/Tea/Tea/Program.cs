using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.ReadFile-> TeaListBasic

            ReadingFile rfteas = new ReadingFile("tea-data.txt");
            TeaBuilder tb = new TeaBuilder();
            List<TeaObj> listoftea = new List<TeaObj>();
            
            foreach (var item in rfteas.teas)
            {
                if (item == "")
                {
                    continue;
                }
                else if (item.StartsWith("#"))
                {
                    continue;

                }
                else
                {
                   listoftea.Add( tb.AddTea(item));

                }
            }

            listoftea=listoftea.OrderBy(x => x.type).ToList();
            Console.WriteLine(String.Join("\n", listoftea));

           
            

            //2.TeaListBasic-> CreateTeaObjects -> List of TeaObjects
            //3.List of Tea objects -> Reveres
            //4. Display (list of thea obecjts)





            Console.ReadKey();

        
        }
    }
}
