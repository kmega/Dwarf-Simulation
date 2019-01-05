using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Tasks;

namespace Tea
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "tea-data.txt";
            
            List<string> readedTeaFile =new FileOps().ReadTeaFile(path);
            
            List<TeaObj> listOfTea = new TeaBuilder().CreateListofTeas(readedTeaFile);
            int task4isdone=0;


            for (; ; )
            {
                Console.WriteLine("Which command do you wish to run?");


            string input = Console.ReadLine();

           
                switch (input)
                {

                    case "1":
                        Task1 task1 = new Task1();
                        task1.DoTask1(listOfTea, readedTeaFile);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "2":
                        Task2 task2 = new Task2();
                        task2.DoTask2(listOfTea, readedTeaFile);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                        case "4":
                        Task4 task4 = new Task4();
                        task4.DoTask4(listOfTea, task4isdone);
                        task4isdone = 1;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "5": 
                        Task5 task5 = new Task5();
                        task5.DoTask5(listOfTea);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;



                    default:
                        break;


                }
            }
          
           

        
        }

       
    }
}
