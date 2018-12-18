using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegexTask
{
    class Program
    {
        public static string file;
        static void Main(string[] args)
        {

            //Odczytanie pliku -> file

            ReadFile file1 = new ReadFile();
            file = file1.Check_Fryderyk_Komciura("../../../../cybermagic/karty-postaci/1807-fryderyk-komciur.md");

            //Odpalenie regexa -> data from file
            Find_data find_data1 = new Find_data();

            string result = find_data1.regex(file, @"(\w+ \w+)");

            result +=" był budowany " + find_data1.regex(file, @"\((\d\d) min.*\)");
            Console.WriteLine(result);

            Create_file save = new Create_file();
            save.save_file("Task1.txt", result);


            Console.ReadKey();
        }
    }
}
