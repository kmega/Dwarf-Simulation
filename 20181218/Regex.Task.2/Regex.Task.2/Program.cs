using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //0. Import Regexow -> brutal force lub sposob zolwia
            Regex Time = new Regex(@"\((\d\d) min.*\)");

            //1. Import wszystkich plikow txt
            var Collection = Directory.GetFiles("/Users/piotr/Desktop/Git/prim" +
                                                      "ary/20181218/cybermagic/karty-postaci");
            //2. Na tekscie znalezc regexy dla czasu i go zsumowac
            Match match;
            int TotalTime = 0;
            foreach (var item in Collection)
            {
                var TempOpenedFile = File.ReadLines(item);
                {
                    foreach (var TimeStringInFile in TempOpenedFile)
                    {
                        match = Time.Match(TimeStringInFile);
                        if (match.Success)
                        {
                            //string TempTimeStringInFile = TimeStringInFile.Replace('(', '\0');
                            string TempTimeStringInFile = TimeStringInFile.Substring(1,2);
                            TotalTime += Convert.ToInt32(TempTimeStringInFile);
                            Console.WriteLine(TempTimeStringInFile);
                        }
                    }
                }

            }
            Console.WriteLine("Total time: {0}", TotalTime);
            //3. Obliczyc ilosc minut
            int TotalHours = TotalTime / 60;
            int TotalMinutes = TotalTime%60;
            //4. Zapisac wynik w pliku
            Console.WriteLine("Total hours: {0} and minutes: {1}", TotalHours, TotalMinutes);
























            ////0. Import Regexow
            //Regex Time = new Regex(@"\((\d\d) min.*\)");
            //Regex Name = new Regex(@"""(\w+ \w+)""");

            ////1. Otworz plik -> uzyj sciezki
            //var OpenedFile = File.ReadLines(@"/Users/piotr/Desktop/Git/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");

            ////2. Na tekscie w pliku znajdz regexa dla czasu
            ////3. Na tekscie w pliku znajdz regexa dla imienia
            //Match match;
            //foreach (var item in OpenedFile)
            //{
            //    match = Time.Match(item);
            //    if (match.Success)
            //    {
            //        Console.WriteLine("Time: {0}", item.Substring(1, item.Length - 2));
            //    }
            //    match = Name.Match(item);
            //    if (match.Success)
            //    {
            //        string temp = item.Replace('"', '\0');
            //        Console.WriteLine("Name: {0}", temp.Substring(7));
            //    }
            //}
            ////4. Stworz nowy plik results.txt i zapis oczekiwany wynik
        }
    }
}
