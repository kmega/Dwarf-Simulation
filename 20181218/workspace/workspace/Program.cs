using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace workspace
{
    class Program
    {
        static string Exercise1()
        {
            string[] text = System.IO.File.ReadAllLines(@"c:\Users\Lenovo\.ssh\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");
            Regex rx = new Regex(@"\((\d\d) min.*\)");
            for (int i = 0; i < text.Length; i++)
            {
                if (rx.Match(text[i]).Success)
                {
                    Console.WriteLine(text[i]);
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            int userPick = 0;
            string input = "";
            input = Console.ReadLine();
            userPick = Convert.ToInt32(input);
            Console.WriteLine("");
            switch (userPick)
            {
                case 1:
                    Exercise1();
                    break;
            }
            Console.ReadLine();
        }
    }
}
