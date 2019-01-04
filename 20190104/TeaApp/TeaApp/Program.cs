using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            //Task2
            //ReadFile(filePath) -> string[] textLines
            string filePath = "/c/c/c/";
            List<string> textLines = FileManager.ReadFile(filePath);
            //BuildTeas(textLines) -> List<Tea>
            List<Tea> teas = TeaFactory.BuildFromFile(textLines);
            //WriteResultsToFile()

        }

        private static void Task1()
        {
            //Task1
            //given filePath
            //ReadFile(filePath) -> string[] textLines
            string filePath = "/c/c/c/";
            List<string> textLines = FileManager.ReadFile(filePath);
            //ReverseRecords(textLines) -> reversed lines;
            List<string> reversedRecords = FileManager.ReverseRecords(textLines);
            //WriteResultsToFile()
        }
    }
}
