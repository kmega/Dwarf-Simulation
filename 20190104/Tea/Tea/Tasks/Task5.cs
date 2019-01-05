using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Tasks
{
   public  class Task5
    {
        List<string> maketeainput = new FileOps().ReadTeaFile("input-file..txt","Windows-1250");


        public void DoTask5(List<TeaObj> tealist)
        {
            string toWrite="";


            foreach (var item in maketeainput)
            {
                string [] parts = item.Split(new string[] { ", " }, StringSplitOptions.None);
                toWrite += parts[0] +", " + 
                    new PrepareTea().Result(tealist,parts[0],double.Parse(parts[1]),double.Parse(parts[2]))+"\n";
                StreamWriter sr = new StreamWriter("result-5.txt");
                sr.Write(toWrite);
                sr.Close();


            }
            Console.WriteLine(toWrite);
        }
                


            
    }
}
