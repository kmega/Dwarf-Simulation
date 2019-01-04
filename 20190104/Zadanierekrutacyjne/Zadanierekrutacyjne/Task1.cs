using System;
using System.Collections.Generic;

namespace Zadanierekrutacyjne
{
    public class Task1
    {
        static void Tas1void(string[] args)
        {
            //read the data from file to string text;
            string path = @"C:\Users\lysia\source\repos\Zadanierekrutacyjne\Zadanierekrutacyjne\bin\Debug\tea-data.txt";
            ReadtheData reader = new ReadtheData();
            List<string> TeaData = reader.Reader(path);

            //reverse the sentences
            ReverseTheSentences reverser = new ReverseTheSentences();
            List<string> Reversesentences = reverser.Reverse(TeaData);
            foreach (string element in Reversesentences)
            {
                Console.WriteLine(element);
            }

            // save it to result 1
            SaveTheData saver = new SaveTheData();
            saver.Save(Reversesentences);


            Console.ReadKey();


        }
    }
}