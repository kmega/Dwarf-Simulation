using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace happy_path_creation_training
{
    class Program
    {
        static void Main(string[] args)
        {
            //File <ReadFile to string> string
            string path = @"1807-fryderyk-komciur.md";
            string fileString = FileOperations.ConvertFileToString(path);
            // string <extract regex> string
            string extractedParam1 = TextParser.ExtractProfileName(fileString);
            string extractedParam2 = TextParser.ExtractTimeToCreate(fileString);
            // string <build output string> string
            string stringOutput = FileOperations.CreateStringToSave(extractedParam1, extractedParam2);
            // string <save to file> File
            string outputPath = @"fk-out.txt";
            FileOperations.SaveToFile(outputPath, stringOutput);
            
            
            
            
            
            /*
             * File - read, create array form file - fileArray
             * fileArray - search line by line for regex expression - string
             * string - save to new File - File
             */

            //DataFile dataFile = new DataFile("1807-fryderyk-komciur.md");
            //string[] a = dataFile.ReadDataFile();

            //string profile = DataFile.SerachArrayForRegExString(a, "title: \"(\\w+ \\w+)\"");
            //string time = DataFile.SerachArrayForRegExString(a, "\\((\\d\\d) min.*\\)");


            

            //Console.WriteLine(dataFile.FilePath);
            Console.ReadKey();








            //string[] result = FileOperations.ReturnStringArrayFromFile("1807-fryderyk-komciur.md");

            //string result2 = FileOperations.ReturnProfileNameAndBuildTime(result);

        }
    }

        
}
