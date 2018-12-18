using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace regex
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // odczytanie danej z pliku: plik = dana z min
                // stworzenie pliku nowego = zapisanie w nim czasu
                // wypisz na konsoli czas
                string path = @"C:\Users\lysia\OneDrive\Pulpit\Corealate_materiały\regexy\primary-develop\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
                if (!File.Exists(path))
                {
              
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;                      
                        Regex rx = new Regex(@"\((\d\d) min.*\)");
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Try to match each line against the Regex.
                            Match match = rx.Match(line);
                            if (match.Success)
                            {                              
                                Console.WriteLine(match.Value);
                                
                            }
                        }
                    }
                }
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
