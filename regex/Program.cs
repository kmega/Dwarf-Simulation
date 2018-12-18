using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace regex
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {   string path = @"C:\Users\lysia\OneDrive\Pulpit\Corealate_materiały\regexy\primary-develop\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
                string line; 
                // odczytanie danej z pliku: plik = dana z min
                // stworzenie pliku nowego = zapisanie w nim czasu
                // wypisz na konsoli czas
                if (!File.Exists(path))
                {

                    using (StreamReader sr = new StreamReader(path))
                    {
                        while ((line = sr.ReadToEnd()) != null)
                        {
                             string SafelyExtractSingleElement(string pattern, string text)
                            {
                                MatchCollection matches = new Regex(pattern).Matches(text);

                                List<string> allResults = new List<string>();
                                foreach (Match match in matches)
                                {
                                    allResults.Add(match.Groups[1].Value);
                                }

                                if (allResults.Count > 0) return allResults.First();
                                else return string.Empty;
                            }
                            Regex rx = new Regex(@"\((\d\d) min.*\)");
                            
                            //pobiera zmienna text, zwraca rezultat metody(czas_)
                            string ExtractTimeToCreate(string text)
                            {
                                text = line;
                                string pattern = @"\((\d\d) min.*\)";
                                return SafelyExtractSingleElement(
                                    @"\((\d\d) min.*\)", text);
                            }
                            // do zmiennej text przypisuje tytul
                            string ExtractProfileName(string text)
                            {
                                text = line;
                                string pattern = @"title: ""(\w+ \w+)";
                                return SafelyExtractSingleElement(
                                    @"title: ""(\w+ \w+)""", text);
                            }
                            
                            // matches to regex przez pattern, lista wynikow, dodanie do listy, zwroc
                            //BRAK PATTERN!!!!
                            // pobiera pattern i text = zwraca czas!
                           
                        }
                    }
                }
                //if (!File.Exists(path))
                //{

                //    using (StreamReader sr = new StreamReader(path))
                //    {
                //        string line;                      
                //        Regex rx = new Regex(@"\((\d\d) min.*\)");
                //        while ((line = sr.ReadLine()) != null)
                //        {
                //            // Try to match each line against the Regex.
                //            Match match = rx.Match(line);
                //            if (match.Success)
                //            {                              
                //                Console.WriteLine(match.Value);

                //            }
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        
    }
}
