using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace happy_path_creation_training_ver2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task4();

        }

        private static void Task4()
        {
            string directoryPath = @"C:\Programming\C#Projects\Corealate\20181218\cybermagic\opowiesci\";
            string outputFilePath = @"C:\Users\Krzysztof\Desktop\out4.txt";
            List<Story> stories = Story.CreateStoriesListFromDirectory(directoryPath);
            OutputData.SaveOutputDataToFile(outputFilePath, OutputData.CreateOutputFour(stories));
        }

        private static void Task3()
        {
            string directoryPath = @"C:\Programming\C#Projects\Corealate\20181218\cybermagic\karty-postaci\";
            string outputFilePath = @"C:\Users\Krzysztof\Desktop\out3.txt";
            List<Character> characters = Character.CreateCharactersListFromDirectory(directoryPath);
            OutputData.SaveOutputDataToFile(outputFilePath, OutputData.CreateOutputThree(characters));
        }

        private static void Task2()
        {
            string directoryPath = @"C:\Programming\C#Projects\Corealate\20181218\cybermagic\karty-postaci\";
            string outputFilePath = @"C:\Users\Krzysztof\Desktop\out2.txt";
            List<Character> characters = Character.CreateCharactersListFromDirectory(directoryPath);
            OutputData.SaveOutputDataToFile(outputFilePath, OutputData.CreateOutputTwo(characters));
        }

        private static void Task1()
        {
            string filePath = @"C:\Programming\C#Projects\Corealate\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string outputFilePath = @"C:\Users\Krzysztof\Desktop\out1.txt";
            Character ch = Character.ExtractCharacterDataFromFile(filePath);
            OutputData.SaveOutputDataToFile(outputFilePath, OutputData.CreateOutputOne(ch));
        }

        
    }
}
