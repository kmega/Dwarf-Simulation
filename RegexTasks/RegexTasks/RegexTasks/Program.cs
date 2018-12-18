using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. plik karty-postaci\1807-fryderyk-komciur -- zapisz do pliku --> resultTask1.txt
            FileReader file1 = new FileReader();
            String[] FryderyKomciurFile = file1.Read_File();

            foreach (var item in FryderyKomciurFile)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
