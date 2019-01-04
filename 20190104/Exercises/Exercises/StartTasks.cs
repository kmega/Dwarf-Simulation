using System;
using System.IO;

namespace Exercises
{
    public class StartTasks
    {
        public string[] FindTeaData()
        {
            string[] linesOfText = File.ReadAllLines(@".../.../.../.../tea-data.txt");
            return linesOfText;
        }

        public void ReverseRecords(string[] linesOfText)
        {
            for (int i = linesOfText.Length; i > 0; i--)
            {
                File.AppendAllText(@".../.../.../.../result-1.txt", linesOfText[i - 1] + Environment.NewLine);
            }
        }
    }
}