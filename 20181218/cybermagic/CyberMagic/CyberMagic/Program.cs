using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //given: poleceniaRegexaczas,polecenei Regexaimie, sciezka, 
            //1. Odczyt pliku (sciezka)
            //2.Przefiltorwanie pliku (poleceniaRegexaczas) -> czas
            //3. Przefiltrowaniepliku (polecenaRegexaimie) -> imie
            //imie, czas -> zapis do pliku - > result.txt

            string path2 = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\";
            string path = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string path3 = @"C:\Users\esmic\primary\20181218\cybermagic\opowiesci";
            string time;
            string name;
            string toWrite;
            TextParser tp = new TextParser();


            List<string> allcharacterscards = new List<string>(new ReadFile().readManyFiles(path2));

            //Task 5

            //1. plik z komendami -> Pobranie komend -> komendy
            string komendy = "1, 2 ,3, 4";
            string[] commands = Regex.Split(komendy, @"[^\d]+");

            StreamWriter srtask = new StreamWriter("resulttask5.txt");

            foreach (var item in commands)
            {
                
                switch (item) {

                    case "1":
                        time = tp.ExtractTimeToCreate(new ReadFile().readFile(path));
                        name = tp.ExtractProfileName(new ReadFile().readFile(path));
                        toWrite = (name + " był budowany " + time + " minut +");
                        new WriteFile().writeFile(toWrite, srtask);
                        Console.WriteLine(toWrite);



                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "2":
                        toWrite = "Czas budowania wszystkich postaci wynosi " + new GetBuiltTime().alltime(allcharacterscards).Sum() + " minut";
                        Console.WriteLine(toWrite);
                        new WriteFile().writeFile(toWrite, srtask);

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "3":

                        int avergetime = 0;
                        int alltime = 0;
                        avergetime = new GetBuiltTime().averageTime(new GetBuiltTime().alltime(allcharacterscards));
                        alltime = new GetBuiltTime().alltime(allcharacterscards).Sum();
                        toWrite = (String.Join("\n", new GetCharactersWithoutTime().charactersWithoutTime(allcharacterscards)) +
                            "\nŚredni czas budowania postaci wynosi: " + avergetime + " minut" +
                            "\nUwzględniając powyższe, postacie do tej pory budowane były najpewniej " +
                           ((avergetime * (new GetCharactersWithoutTime().charactersWithoutTime(allcharacterscards).Count - 1))
                        + alltime) + " minut");
                        Console.WriteLine(toWrite);
                        new WriteFile().writeFile(toWrite, srtask);
                        break;

                    case "4": 
                        //Task 4
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        //1.Załadowanie opowieści -> lista z opowieściami
                        //2.Wyszukiwanie tych które zawierają Magdę(lista z opowieściami)
                        //3. Zapis do pliku

                        List<string> allstories = new List<string>(new ReadFile().readManyFiles(path3));

                        toWrite = new MagdaDetector().magdaDetector(allstories);
                        Console.WriteLine(toWrite);
                        new WriteFile().writeFile(toWrite, srtask);
                        break;



                }
            }


            







            srtask.Close();
            Console.ReadKey();




        }

        
    }

}
