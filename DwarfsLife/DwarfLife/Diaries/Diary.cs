using System;
using System.IO;

namespace DwarfLife.Diaries
{
    public abstract class Diary
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
    }

    public class ConsoleLogger : Diary
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : Diary
    {
        public string filePath = @"DwarfsLifeDiary.txt";
        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
}
