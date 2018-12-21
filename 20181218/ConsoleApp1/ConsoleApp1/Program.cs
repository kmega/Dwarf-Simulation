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

        static string PickMagdaPatirilTales(string[] text)
        {
            string tale = "";
            Regex rx = new Regex(@"# Zas.ugi.*?Magda Patiril.*?#");
            for (int i = 0; i < text.Length; i++)
            {
                    if (rx.Match(text[i]).Success)
                    {
                        tale = PickTale(text);
                    }
            }
            return tale;
        }

        static string PickTale(string[] text)
        {
            string tale = "";
            Regex rx = new Regex(@"title: +""([\w\s] +)""");
            for (int i = 0; i < text.Length; i++)
            {
                    if (rx.Match(text[j]).Success)
                    {
                        tale = text[j];
                    }
            }
            return tale;
        }



        static void Main(string[] args)
        {
            string[] filePath = System.IO.File.ReadAllLines(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt");
            if (filePath.Length == 0)
            {
                WriteFryderykKomciurBuildTime();
                WriteAllCharactersBuildTime();
                WriteAvarageBuildTime();
                FindStoriesWithMagdaPatiril();
                Console.WriteLine("Written to fryderykKomciur.txt. Press anything to quit.");
            }
            else
            {
                Console.WriteLine("File is not empty. Press anything to quit.");
            }
            Console.ReadKey();
        }



        static void WriteFryderykKomciurBuildTime()
        {
            Console.Clear();
            string[] linesOfText = System.IO.File.ReadAllLines(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");
            string text = PickName(linesOfText)
                + "byl budowany "
                + PickTime(linesOfText)
                + " minuty";
            System.IO.File.WriteAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", text);
        }

        static void WriteAllCharactersBuildTime()
        {
            Console.Clear();
            string text = "Wszystkie postacie do tej pory budowane były "
                + PickBuildTime() / 60
                + " godzin "
                + PickBuildTime() % 60
                + " minut";
            System.IO.File.AppendAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", Environment.NewLine + text);
        }

        static void WriteAvarageBuildTime()
        {
            Console.Clear();
            int unbuildNamesCount = PickUnbuildNames().Split(' ').Length / 2;
            int avarageBuildTime = PickBuildTime() / unbuildNamesCount;
            int wholeBuildTime = PickBuildTime() + avarageBuildTime * unbuildNamesCount;
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
        }

        static void FindStoriesWithMagdaPatiril()
        {
            string[] linesOfText;
            string tales = "";
            foreach (string file in Directory.EnumerateFiles(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci", "*.md"))
            {
                linesOfText = File.ReadAllLines(file);
                tales += PickMagdaPatirilTales(linesOfText) + Environment.NewLine;
            }
            string text = "Magda Patiril występowała w następujących Opowieściach:" 
                + Environment.NewLine
                + tales;
            System.IO.File.AppendAllText(@"c:\Users\Lenovo\.ssh\primary\20181218\fryderykKomciur.txt", Environment.NewLine + text);
            Console.WriteLine(text);
        }
    }
}
