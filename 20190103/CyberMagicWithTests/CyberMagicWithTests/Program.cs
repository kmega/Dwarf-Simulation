using CyberMagicWithTests.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;


namespace CyberMagicWithTests
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sr = new StreamWriter("result.txt");

            Task1 task1 = new Task1();
            Console.WriteLine(task1.GetKomciur());
            sr.WriteLine(task1.GetKomciur());


            sr.Close();
            Console.ReadKey();
        }
    }
}
