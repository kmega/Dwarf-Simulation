using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Tasks
{
    public class Task4
    {
        public void DoTask4(List<TeaObj> tealist, int isdone)
        {
            

            Console.WriteLine("What tea you want to do?");
            string namegiven = Console.ReadLine();
            Console.WriteLine("What temp you want?");
            double tempgiven = double.Parse(Console.ReadLine());

            Console.WriteLine("What time do you want to prepare it?");
            double timegiven = Double.Parse(Console.ReadLine());

            string result = new PrepareTea().Result(tealist, namegiven, tempgiven, timegiven);
            string inputdata = "Input: " + namegiven + ", " + tempgiven + ", " + timegiven;
            string toWrite = inputdata + "\nResult: " + result+"\n\n";
            Console.WriteLine(toWrite);

            if (isdone == 0)
            {
                StreamWriter sr = new StreamWriter("result-4.txt");
               
                sr.WriteLine(toWrite);
                sr.Close();
                
            }
            else
            {
                File.AppendAllText ("result-4.txt", toWrite);
              
            }


        }
        
        }

       
    }


