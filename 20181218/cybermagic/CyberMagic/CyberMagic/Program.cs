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

        public static string readFile(string path) {
            
                 string txt = File.ReadAllText(path);
            
            return txt;
        }


        public static List<string> readManyFiles(string path)
        {
            
            List<string> files = Directory.GetFiles(path).ToList();
            List<string> alltext = new List<string>();
            

            foreach (string temp in files)
            {
                alltext.Add (readFile(temp));
            }
            return alltext;

        }

        

        public static void writeFile(string toWrite, string fileName)
        {
            StreamWriter sr = new StreamWriter(fileName);
            sr.Write(toWrite);
            sr.Close();
        }

        public static int[] alltime(List <string> files)
        {
            int[] alltime ={ 0, 0};

            foreach (var item in files)
            {
                string time;
                time = (new TextParser().ExtractTimeToCreate(item));
                if (time == "")
                {
                    continue;
                }
                else
                {
                    alltime[0] += Int32.Parse(time);
                    alltime[1]++;
                }
            }
            return alltime;
        }

        public static string[] charactersWithoutTime (List<string> files)
        {
            string temp =  "Postaci bez czasu budowania\n";
            int i = 0 ;

            foreach (var item in files)
            {

                if (new TextParser().ExtractTimeToCreate(item) == "" && !(new TextParser().ExtractProfileName(item) == ""))
                {
                    temp += new TextParser().ExtractProfileName(item) + "\n";
                    i++;
                }
                
            }
            string[] txt = { temp, i.ToString() };
            return txt;
        }

        public static int averageTime (List<string> files)
        {
            int average = (alltime(files)[0] / alltime(files)[1]);
            return average;
        } 
        



        static void Main(string[] args)
        {
            //given: poleceniaRegexaczas,polecenei Regexaimie, sciezka, 
            //1. Odczyt pliku (sciezka)
            //2.Przefiltorwanie pliku (poleceniaRegexaczas) -> czas
            //3. Przefiltrowaniepliku (polecenaRegexaimie) -> imie
            //imie, czas -> zapis do pliku - > result.txt

            string path2 = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\";
            string path = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string time;
            string name;
            string toWrite;
            TextParser tp = new TextParser();


            List<string> alltext = new List<string>(readManyFiles(path2));

            //Task 1


            time = tp.ExtractTimeToCreate(readFile(path));
            name = tp.ExtractProfileName(readFile(path));
            toWrite = (name + " był budowany " + time + " minut");
            writeFile(toWrite, "result1.txt");
            Console.WriteLine(toWrite);

            

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Task 2

            
           
            toWrite = "Czas budowania wszystkich postaci wynosi " + alltime(alltext) +  " minut";
            Console.WriteLine(toWrite);
            writeFile(toWrite, "result2.txt");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Task 3

           
            toWrite = (charactersWithoutTime(alltext)[0]+ "\nŚredni czas budowania postaci wynosi: " + averageTime(alltext) +" minut" +
                "\nUwzględniając powyższe, postacie do tej pory budowane były najpewniej " +
                (averageTime(alltext) * Int32.Parse(charactersWithoutTime(alltext)[1]) + alltime(alltext)[0]) + " minut");
            Console.WriteLine(toWrite);
            writeFile(toWrite, "result3.txt");

            //Task 4

            //1.Załadowanie opowieści -> lista z opowieściami
            //2.Wyszukiwanie 

         





            Console.ReadKey();




        }


       


    }

}
