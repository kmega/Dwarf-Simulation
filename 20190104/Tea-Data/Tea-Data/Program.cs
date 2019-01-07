using System;

namespace Tea_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIO read = new FileIO();
            string[] teaData = read.TeaData();


            UserInput execute = new UserInput();
            string output = execute.Task(teaData);


            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
