using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Tea-Data-Tests")]

namespace Tea_Data
{
    internal class UserInput
    {
        internal string Task(string[] teaData)
        {
            ExecuteTask execute = new ExecuteTask();
            int input = 0;
            string message = "";
            for (int i = 0; i < teaData.Length; i++)
            {
                message += teaData[i] + "\n";
            }
            message += "\n1 - Reverse Records" +
                "\n2 - Sort Teas" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\nChoose the task:";
            Console.WriteLine(message);
            while (input < 1 || input > 6)
            {
                string userInput = Console.ReadLine();
                input = CheckInput(userInput, message);
            }
            switch (input)
            {
                case 1:
                    message = execute.ReverseRecords(teaData);
                    break;
                case 2:
                    message = execute.SortRecords(teaData);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
            Console.Clear();
            FileIO write = new FileIO();
            write.Results(message, input);
            return message + "\nSaved to result-" + input + ".txt. Press anything to quit.";
        }


        internal int CheckInput(string userInput, string message)
        {
            int input = 0;
            bool isValidNumber = false;
            while (input < 1 || input > 6 && isValidNumber == false)
            {
                try
                {
                    input = Convert.ToInt32(userInput);
                    if (input >= 1 && input <= 6)
                    {
                        isValidNumber = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input.\n\n" + message);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input.\n\n" + message);
                }
            }
            return input;
        }
    }
}