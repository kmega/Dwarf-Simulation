using System;
using System.IO;

namespace JobOne
{
    class Reverse
    {
        private static void Main()
        {
            int rows = 8;
            int columns = 5;
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            //string[] dniTygodnia = { "poniedziałek", "wtorek", "śr", "cz", "pi", "so", "ni" };
            string[] plik = System.IO.File.ReadAllLines(@"./tea-data.txt"); // the txt file must be in the same directory as the executable file ( EXE ) 
            int[,] matrix = new int[rows, columns];                                                                //string test = "TEST test TEST ";
                                                                            // Display the file contents by using a foreach loop.
                                                                            //System.Console.WriteLine("TEst " + data[8,2]);

            for (int i = 0; i < plik.Length; i++)
            {
                //bierzemy pierwsza linie
                //robimy tymczasowa tablice - dzielimy string
                string[] tmp = plik[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tmp.Length; j++)
                {
                    //zapelniamy macierz wartosciami
                    matrix[i, j] = int.Parse(tmp[j]);
                }
            }

            Console.WriteLine("\n" + "Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}