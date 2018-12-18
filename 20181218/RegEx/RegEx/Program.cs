using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace RegEx
{
    class Program
    {
        public class GetRegexResult
        {
            Regex regex = new Regex(@"\((\d\d) min.*\)");

            public static void MatchKomciur(string inFile, string outFile)
            {                
                string fKomciur = File.ReadAllText(inFile);
                string[] fKomciutrResult = Regex.Split(inFile, @"\((\d\d) min.*\)");
            }
            
        }
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\((\d\d) min.*\)");
            string pathFKomciur = @"C:\Code\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string result1 = @"result1.txt";

            GetRegexResult komciurRegex = new GetRegexResult.MatchKomciur(pathFKomciur, result1);
           
            
        }
    }
}
