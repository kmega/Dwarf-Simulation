using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace RegexTraining
{
    class Program
    {
        public static void Task1(string inputPath,string outputPath)
        {
            // REGEX DLA CZASU \((\d\d) min.*\)
            // REGEX DLA IMIENIA title: "(\w+ \w+)"
            const string quote = "\"";
            Regex timeRegex = new Regex(@"\((\d\d) min.*\)");
            Regex nameRegex = new Regex("title: " + quote + @"(\w+ \w+)"  + quote);
            string name = "";
            string time = "";
            using (StreamReader streamReader = new StreamReader(inputPath))
            {
                string line = "";
                while((line = streamReader.ReadLine()) != null)
                {
                    if (timeRegex.IsMatch(line))
                        time = line;
                    if (nameRegex.IsMatch(line))
                        name = line;
                }  
            }
            Console.WriteLine(name + " " + time);
            


        }
        static void Main(string[] args)
        {
            Task1(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md", "");
            Console.ReadKey();
        }
    }
}
