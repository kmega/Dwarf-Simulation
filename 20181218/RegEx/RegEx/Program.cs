using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using VivaRegex;

namespace RegEx
{
    class Program
    {            
        static void Main(string[] args)
        {
            string timeKomciur;
            string nameKomciur;
            string pathFKomciur = @"C:\Code\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string result1 = @"C:\Code\primary\20181218\RegEx\RegEx\result1.txt";

            string[] fKomciur = File.ReadAllLines(pathFKomciur);
            TextParser tp = new TextParser();

            var join = string.Join("\n", fKomciur);
            timeKomciur = tp.ExtractTimeToCreate(join);
            nameKomciur = tp.ExtractProfileName(join);
            
            File.WriteAllText(result1, nameKomciur + " byl budowany " + timeKomciur + " minuty");
                       
        }
    }
}
