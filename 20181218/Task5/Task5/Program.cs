using System;
using System.Collections.Generic;

namespace Task5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //ConfigFileReader(path) -> string ReadConfig
            string path = @"/Users/piotr/Desktop/Git/primary/20181218/Task5/conifgFile.txt";
            List<string> configCommands = new ConfigFileReader().ConfigReader(path);

            //configCommands -> list<int> intListCommands
            //List<int> ListOfCommands = new CommandFinder().ReadCommands(configCommands);
            //use Regex to extract commands -> List<int> Commands
            //TaskOpener(Commands) -> 
        }
    }

    class CommandFinder
    {
        public List<int> ReadCommands(string configCommands)
        {
            List<int> tempCommandList = new List<int>();
            foreach (char item in configCommands)
            {

            }
            return null;
        }
    }
}
