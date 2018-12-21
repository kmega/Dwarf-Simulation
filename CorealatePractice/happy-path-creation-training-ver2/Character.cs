using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace happy_path_creation_training_ver2
{
    class Character
    {
        public string ProfileName;        
        public string FileAsString;
        public string TimeToCreate;

        public string CreateFileAsString(string filePath)
        {
            return FileAsString = File.ReadAllText(filePath);
        }

        public void SetProfileName(string fileAsString)
        {
            ProfileName = TextParser.ExtractProfileName(fileAsString);
        }

        public void setTimeToCreate(string fileAsString)
        {
            TimeToCreate = TextParser.ExtractTimeToCreate(fileAsString);
        }

        public static Character ExtractCharacterDataFromFile(string filePath)
        {
            Character character = new Character();
            character.SetProfileName(character.CreateFileAsString(filePath));
            character.setTimeToCreate(character.CreateFileAsString(filePath));
            return character;
        }

        public static List<Character> CreateCharactersListFromDirectory(string directoryPath)
        {
            List<Character> characters = new List<Character>();
            string[] filesInDirectoryArray = Directory.GetFiles(directoryPath);
            foreach (string s in filesInDirectoryArray)
            {
                characters.Add(Character.ExtractCharacterDataFromFile(s));
            }
            return characters;
        }




    }
}
