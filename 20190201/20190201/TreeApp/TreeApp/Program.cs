using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace TreeApp
{
   
    class Program
    { 
        static string extractPath(List<Record> records,int depth)
        {
            string result = "";
            int i = 0;
            while(i <= depth)
            {
                foreach(Record record in records)
                {
                    if(record.depth == i)
                    {
                        result += record.name + "/";
                        break;
                    }
                }
                i++;
            }
            return result;
        }
        public static List<Record> ReadTreeFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            List<Record> records = new List<Record>();
            foreach (string line in lines)
            {
                int indexOfBeginningRecord = line.IndexOf("1. ");
                int depth = indexOfBeginningRecord / 4;
                string name = line.Substring(indexOfBeginningRecord + 3);
                string path = extractPath(records, depth);
                records.Add(new Record(name, depth, path));
            }
            return records;
        }
        static void Main(string[] args)
        {
            List<Record> firstTree = ReadTreeFromFile(@"C:\Users\Lenovo\Desktop\a.txt");
            List<Record> secondTree = ReadTreeFromFile(@"C:\Users\Lenovo\Desktop\b.txt");
            
            Console.WriteLine("RESULT");
            firstTree.AddRange(secondTree);
            List<Record> result = new List<Record>();
            for(int i=0;i<firstTree.Count;i++)
            {
                if (!result.Contains(firstTree[i]))
                    result.Add(firstTree[i]);
            }
            printTree(result);
            
            
            




            Console.ReadLine();
        }

        private static void printTree(List<Record> tree)
        {
            foreach(Record record in tree)
                Console.WriteLine(record);
        }
    }
}
