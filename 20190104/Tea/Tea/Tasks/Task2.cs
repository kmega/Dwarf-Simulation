using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Tasks
{
   public class Task2
    {

        public void DoTask2(List<TeaObj> tealist, List<string> teafile)
        {
            tealist = tealist.OrderBy(x => x.name).ToList();
            StreamWriter sr = new StreamWriter("result-2.txt");
            string toWrite = teafile[0] + "\n\n" + String.Join("\n", tealist);

            tealist = tealist.OrderBy(x => x.type).ToList();
            toWrite += "\n\n" + teafile[0] + "\n\n" + String.Join("\n", tealist);

            Console.WriteLine(toWrite);
            sr.Write(toWrite);
            sr.Close();
        }
    }
}
