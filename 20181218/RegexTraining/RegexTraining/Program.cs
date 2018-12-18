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
            TextParser textParser = new TextParser();
            string profilName = "";
            string timeToCreate = "";
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(inputPath))
            {
                string line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(line);
                }
            }
            profilName = textParser.ExtractProfileName(stringBuilder.ToString());
            timeToCreate = textParser.ExtractTimeToCreate(stringBuilder.ToString());
            using (StreamWriter streamWriter = new StreamWriter(outputPath))
            {
                streamWriter.WriteLine('"' + "{0} był budowany {1} minuty" + '"',profilName,timeToCreate);
            }





        }
        static void Main(string[] args)
        {
            Task1(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md", "outputTask1.txt");
            Console.ReadKey();
        }
    }
}
