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
        static string Exercise1()
        {
            Console.Clear();
            bool isName = true;
            string[] text = System.IO.File.ReadAllLines(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");
            Regex rx = new Regex(@"title: ""(\w+ \w+)""");
            for (int i = 0; i < text.Length; i++)
            {
                if (rx.Match(text[i]).Success && isName == true)
                {
                    Console.Write(text[i].Split(' ')[1].Replace('"', ' ') + " " + text[i].Split(' ')[2].Replace('"', ' '));
                    rx = new Regex(@"\((\d\d) min.*\)");
                    isName = false;
                }
                if (rx.Match(text[i]).Success)
                {
                    text[i] = text[i].Replace("(", "").Replace(")", "").Replace("min", "");
                    Console.Write("był budowany " + text[i] + "minuty.");
                    break;
                }
            }
            return null;
        }

        static string Exercise2()
        {
            Console.Clear();
            string text;
            int buildTime = 0;
            Regex rx = new Regex(@"\((\d\d) min.*\)");
            foreach (string file in Directory.EnumerateFiles(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci", "*.md"))
            {
                text = File.ReadAllText(file);
                if (rx.Match(text[i]).Success)
                {
                    
                }
            }
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
                    Exercise1();
                    break;
                case 2:
                    Exercise2();
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
