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
        static string PickName(string[] linesOfText)
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
            name = name.Replace('"', ' ').Replace("title:  ", "");
            return name;
        }

        static string PickTime(string[] linesOfText)
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
                time = time.Split(' ')[0].Replace("(", "").Replace(")", "");
                return time;
            }
        }

        static string PickUnbuildNames()
        {
            string[] linesOfText;
            string names = "";
            foreach (string file in Directory.EnumerateFiles(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci", "*.md"))
            {
                linesOfText = File.ReadAllLines(file);
                if (Convert.ToInt32(PickTime(linesOfText)) == 0)
                {
                    names += PickName(linesOfText) + Environment.NewLine;
                }
            }
            return names;
        }

        static int PickBuildTime()
        {
            string[] linesOfText;
            int buildTime = 0;
            foreach (string file in Directory.EnumerateFiles(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci", "*.md"))
            {
                linesOfText = File.ReadAllLines(file);
                buildTime += Convert.ToInt32(PickTime(linesOfText));
            }
            return buildTime;
        }




        static string WriteFryderykKomciurBuildTime()
        {
            Console.Clear();
            string[] linesOfText = System.IO.File.ReadAllLines(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");
            string text = "";
            text = PickName(linesOfText);
            text = text + "byl budowany ";
            text = text + PickTime(linesOfText);
            text = text + " minuty";
            System.IO.File.WriteAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", text);
            Console.WriteLine(text + "\n\nChoose exercise using 1-n. Exit using 0.");
            return null;
        }

        static string WriteAllCharactersBuildTime()
        {
            Console.Clear();
            int buildTime = PickBuildTime();
            string text = "Wszystkie postacie do tej pory budowane były " + buildTime / 60 + " godzin " + buildTime % 60 + " minut";
            System.IO.File.AppendAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", Environment.NewLine + text);
            Console.WriteLine(text + "\n\nChoose exercise using 1-n. Exit using 0.");
            return null;
        }

        static string WriteAvarageBuildTime()
        {
            Console.Clear();
            int avarageBuildTime = PickBuildTime() / (PickUnbuildNames().Split(' ').Length / 2);
            int wholeBuildTime = PickBuildTime() + (avarageBuildTime * PickUnbuildNames().Split(' ').Length / 2);
            string text = "Postacie, ktore nie maja podanego czasu to:"
                + Environment.NewLine
                + PickUnbuildNames() 
                + Environment.NewLine 
                + "Średni czas budowania postaci to: " 
                + avarageBuildTime
                + " minut." 
                + Environment.NewLine
                + "Uwzględniając powyższe, postacie do tej pory budowane były najpewniej " 
                + wholeBuildTime / 60
                + " godzin " 
                + wholeBuildTime % 60
                + " minut.";
            System.IO.File.AppendAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", Environment.NewLine + text);
            Console.WriteLine(text);
            return null;
        }



        static void Main(string[] args)
        {
            int userPick = -1;
            string input = "";
            Console.WriteLine("Choose exercise using 1-n. Exit using 0.");
            while (userPick != 0)
            {
                input = Console.ReadLine();
                try
                {
                    userPick = Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("");
                }
                switch (userPick)
                {
                    case 0:
                        Console.WriteLine("\nThanks.");
                        break;
                    case 1:
                        WriteFryderykKomciurBuildTime();
                        break;
                    case 2:
                        WriteAllCharactersBuildTime();
                        break;
                    case 3:
                        WriteAvarageBuildTime();
                        break;
                    default:
                        Console.WriteLine("\nWrong input.");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
