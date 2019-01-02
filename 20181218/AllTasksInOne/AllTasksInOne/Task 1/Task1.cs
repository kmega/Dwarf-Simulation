using System;
using System.IO;

namespace AllTasksInOne
{
    class Task1
    {
        public void Main()
        {
            string komciurValue = File.ReadAllText(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");

            string name = GetName(komciurValue);
            int time = GetTime(komciurValue);
            DisplayResult(name, time);
            SaveToFile(name, time);
        }

        private void SaveToFile(string name, int time)
        {
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\AllTasksInOne\AllTasksInOne\Results\Result1.txt");
            streamWriter.Write("{0} byl budowany {1} minuty", name, time);
            streamWriter.Close();
        }

        private void DisplayResult(string name, int time)
        {
            Console.WriteLine("### Task 1:");
            Console.WriteLine("{0} byl budowany {1} minuty", name, time);
            Console.WriteLine();
        }

        private int GetTime(string komciurValue)
        {
            TextParser textParser = new TextParser();
            return Convert.ToInt32(textParser.ExtractTimeToCreate(komciurValue));
        }

        private string GetName(string komciurValue)
        {
            TextParser textParser = new TextParser();
            return textParser.ExtractProfileName(komciurValue);
        }
    }
}
