using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Tasks
{
    public class Task1
    {
        public void DoTask1(List<TeaObj> tealist, List<string>teafile)
        {
           tealist= tealist.OrderBy(x => x.name).ToList();
            StreamWriter sr = new StreamWriter("result-1.txt");
            string toWrite = teafile[0] + "\n\n" + String.Join("\n", tealist);

            tealist.Reverse();
            toWrite +="\n\n" + teafile[0] + "\n\n" + String.Join("\n", tealist);

            Console.WriteLine(toWrite);
            sr.Write(toWrite);
            sr.Close();
        }

    }
}
