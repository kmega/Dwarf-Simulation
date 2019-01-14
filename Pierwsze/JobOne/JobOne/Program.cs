using System;

namespace JobOne
{
    class Reverse
    {
        private static void Main()
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.

            string[] data = System.IO.File.ReadAllLines(@"./tea-data.txt"); // the txt file must be in the same directory as the executable file ( EXE ) 
         
            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of tea-data.txt after loading  = ");
           foreach (string line in data)
             {
                Console.WriteLine(line);  // writing line by line in console 
             }
            string[]  detaReverse = data;
            Array.Reverse(detaReverse); //Reverse of the arra

            System.Console.WriteLine("\n\t" + "Contents of tea-data.txt after before ( result-2.txt )  = ");
            foreach (string line in detaReverse)
            {
                Console.WriteLine("\t" + line);
            }
            System.IO.File.WriteAllLines(@"./result-2.txt", data); // writing line by line in console 

            // Keep the console window open in debug mode.
            Console.WriteLine("\n" + "Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
