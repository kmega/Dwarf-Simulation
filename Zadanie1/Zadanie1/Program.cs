using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using VivaRegex;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextParser textParser = new TextParser();
            var readFile = File.ReadAllText("C:/Users/Lenovo/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");
            string folderPath = @"cybermagic\karty-postaci";
            string profileName = textParser.ExtractProfileName(readFile);
            string timeToBuild = textParser.ExtractTimeToCreate(readFile);
            TextFileCreator.CreateOrAppend("result1.txt",$"{profileName} był budowany {timeToBuild} min");
            TimeSpan totalTimeToBuildHeroes = TimeSpan.FromMinutes(Hero.TimeOfBuildingAllHeroes(folderPath));
            TextFileCreator.CreateOrAppend("result2.txt", $"Wszystkie postacie do tej pory budowane były " +
                $"{totalTimeToBuildHeroes.Hours} godzin i {totalTimeToBuildHeroes.Minutes} minut.");

          
            

            Console.ReadLine();
        }
    }
}
