using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            // dane wejściowe = > Wczytanie pliku = > tekst

            string path = @"C:\Users\Lenovo\Desktop\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string openFile = File.ReadAllText(path);


            //plik wejściowy => wyszukanie czasu => czas
            Regex regexTime = new Regex(@"\((\d\d) min.*\)");
            Match time = regexTime.Match(openFile);
            string buildTime = (time.ToString()).Substring(1, 2);



           

            // plik wejściowy=> wyszukanie imienie = > imie
            Regex regexTitle = new Regex(@"(\w+ \w+)");
            Match title = regexTitle.Match(openFile);

            // dane wyjściowe => zapisz do pliku => plik

            string result = $"{title} był budowany {buildTime} minuty";

            Console.WriteLine(result);
            // string  path2 = @"C:\Users\Lenovo\Desktop\primary\20181218\result.md";
            //File.WriteAllText(path2, result);

            Console.ReadKey();
        }
    }
}
