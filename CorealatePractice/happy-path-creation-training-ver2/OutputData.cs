using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace happy_path_creation_training_ver2
{
    class OutputData
    {
        public static void SaveOutputDataToFile(string outputFilePath, string outputString)
        {
            File.WriteAllText(outputFilePath, outputString);
        }

        public static string CreateOutputOne(Character character)
        {
            return character.ProfileName + " był budowany przez " + character.TimeToCreate + " minuty";
        }



        public static string CreateOutputTwo(List<Character> characters)
        {
            List<string> timesToBuild = characters.Select(s => s.TimeToCreate).ToList();
            double time = 0;
            foreach (string s in timesToBuild)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    time += double.Parse(s);
                }
            }
            TimeSpan ts = TimeSpan.FromMinutes(time);
            return "Wszystkie postacie do tej pory budowane były " + ts.Hours + " godzin " + ts.Minutes + " minuty";
        }

        internal static string CreateOutputFour(List<Story> stories)
        {
            StringBuilder sb = new StringBuilder();



            List<Story> storiesWithMagdaPatiril = stories
                .Where(s => TextParser.ExtractStuffWithMagda(s.StoryAsString)!= "")
                .ToList();



            sb.Append("Magda Patiril występowała w następujących Opowieściach: \n");
            foreach (var s in storiesWithMagdaPatiril)
            {
                sb.Append("* " + s.Title + "\n");
            }
            return sb.ToString();

        }

        internal static string CreateOutputThree(List<Character> characters)
        {
            List<Character> charactersWithoutBuildTime = characters.Select(s => s).Where(n => string.IsNullOrEmpty(n.TimeToCreate)).ToList();


            StringBuilder sb = new StringBuilder();
            sb.Append("Postacie, które nie mają podanego czasu to:\n\n");
            foreach (Character s in charactersWithoutBuildTime)
            {
                sb.Append("# " + s.ProfileName + "\n");
            }

            List<string> timesToBuild = characters.Select(s => s.TimeToCreate).Where(n => !string.IsNullOrEmpty(n)).ToList();
            List<double> result = timesToBuild.Select(x => double.Parse(x)).ToList();
            double average = result.Average();
            sb.Append("\nŚredni czas budowania postaci to: " + average + " minut.\n\n");

            double numberOfCharacters = characters.Count();
            double timeToBuildAllCharactersByAvg = numberOfCharacters * average;
            TimeSpan ts = TimeSpan.FromMinutes(timeToBuildAllCharactersByAvg);
            sb.Append("Uwzględniając powyższe, postacie do tej pory budowane były najpewniej " + ts.Hours + " godzin " + ts.Minutes + " minuty.");
            return sb.ToString();
        }
    }
}
