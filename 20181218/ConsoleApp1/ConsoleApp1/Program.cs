using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace workspace
{
    class Program
    {
        static string TakeName(string[] linesOfText)
        {
            string name = "";
            Regex rx = new Regex(@"title: ""(\w+ \w+)""");
            for (int i = 0; i < linesOfText.Length; i++)
            {
                if (rx.Match(linesOfText[i]).Success)
                {
                    name = linesOfText[i];
                    break;
                }
            }
            return name;
        }

        static string TakeTime(string[] linesOfText)
        {
            string time = "";
            Regex rx = new Regex(@"\((\d\d) min.*\)");
            for (int i = 0; i < linesOfText.Length; i++)
            {
                if (rx.Match(linesOfText[i]).Success)
                {
                    time = linesOfText[i];
                    break;
                }
            }
            if (time == "")
            {
                return "0";
            }
            else
            {
                return time;
            }
        }

        static string WriteFryderykKomciurBuildTime()
        {
            Console.Clear();
            string[] linesOfText = System.IO.File.ReadAllLines(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");
            string text = "";
            text = TakeName(linesOfText);
            text = text.Replace('"', ' ').Replace("title:  ", "") + "byl budowany ";
            text = text + TakeTime(linesOfText);
            text = text.Replace("(", "").Replace(")", "").Replace("min", "") + "minuty";
            System.IO.File.WriteAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", text);
            Console.WriteLine(text);
            return null;
        }

        static string WriteAllCharactersBuildTime()
        {
            Console.Clear();
            string[] linesOfText;
            string time = "";
            int buildTime = 0;
            foreach (string file in Directory.EnumerateFiles(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci", "*.md"))
            {
                linesOfText = File.ReadAllLines(file);
                time = TakeTime(linesOfText);
                time = time.Replace("(", "").Replace(")", "").Replace("min", "");
                time = time.Split(' ')[0];
                buildTime += Convert.ToInt32(time);
            }
            time = "Wszystkie postacie do tej pory budowane były godzin minut";
            System.IO.File.WriteAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", time);
            Console.WriteLine(time);
            return null;
        }

        static void Main(string[] args)
        {
            int userPick = 0;
            string input = "";
            Console.WriteLine("Choose exercise using 1-n.");
            input = Console.ReadLine();
            userPick = Convert.ToInt32(input);
            switch (userPick)
            {
                case 1:
                    WriteFryderykKomciurBuildTime();
                    break;
                case 2:
                    WriteAllCharactersBuildTime();
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
