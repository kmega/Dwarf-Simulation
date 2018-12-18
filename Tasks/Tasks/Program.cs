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
            var openFile = ReadFile(path);


            //plik wejściowy => wyszukanie czasu => czas
            TextParser textParser = new TextParser();
            string time = textParser.ExtractTimeToCreate(openFile);
            //Regex regexTime = new Regex(@"\((\d\d) min.*\)");
            //Match time = regexTime.Match(openFile);
            //string buildTime = (time.ToString()).Substring(1, 2);

            // plik wejściowy=> wyszukanie imienia = > imie
            string name = textParser.ExtractProfileName(openFile);
            //Regex regexTitle = new Regex(@"(\w+ \w+)");
            //Match title = regexTitle.Match(openFile);


            // dane wyjściowe => zapisz do pliku => plik

            //string result = $"{title} był budowany {buildTime} minuty";
            string result = $"{name} był budowany {time} minuty";

            string path2 = @"C:\Users\Lenovo\Desktop\primary\Tasks\result.md";
            File.WriteAllText(path2, result);

            //Task 2


            string pathDirectory = @"C:\Users\Lenovo\Desktop\primary\20181218\cybermagic\karty-postaci";
            string[] fileEntries = Directory.GetFiles(pathDirectory);


            List<Character> ListOfCharacters = new List<Character>();

            foreach (var item in fileEntries)
            {
                var openFile2 = ReadFile(item);
                string name2 = textParser.ExtractProfileName(openFile2);
                string time2 = textParser.ExtractTimeToCreate(openFile);

                // poprawić z null
                if (int.Parse(time2) > 0 && name2 != null)
                {
                    ListOfCharacters.Add(new Character { Title = name2, Time = time2, });
                }
             

            }

            foreach (var item in ListOfCharacters)
            {
                Console.WriteLine(item);
            }



            string path3 = @"C:\Users\Lenovo\Desktop\primary\Tasks\resul2.md";
            File.WriteAllText(path3, result);



            Console.ReadKey();

        }

        private static string ReadFile(string path)
        {
            string source = path;
            string openFile = File.ReadAllText(source);
            return openFile;
        }
    }
}
