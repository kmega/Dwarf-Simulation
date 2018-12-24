using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //ConfigFileReader(path) -> string ReadConfig
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\Task5\conifgFile.txt";//@" / Users/piotr/Desktop/Git/primary/20181218/Task5/conifgFile.txt";
            string configCommands = new ConfigFileReader().ConfigReader(path);

            //configCommands -> list<int> list of numeric commands
            List<int> ListOfCommands = new Extractor().Extract(configCommands);

            //ListOfCommands -> open EXEs of built programs
            new Executor().OpenCommands(ListOfCommands);

            Console.ReadKey();
        }
    }

    class Executor
    {
        public void OpenCommands(List<int> listOfCommands)
        {
            foreach (int command in listOfCommands)
            {
                CommandSwitcher(command);
            }
        }

        private void CommandSwitcher(int option)
        {
            switch (option)
            {
                case 1:
                    Process.Start(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\Regex\Regex\bin\Debug\Regex.exe");
                    break;

                default:
                    break;
            }
        }
    }
}
