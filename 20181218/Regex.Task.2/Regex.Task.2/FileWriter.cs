using System.IO;

namespace Task2
{
    class FileWriter
    {
        public void WrtieToFile(int TotalTime)
        {
            FinalTimeResult finalTimeResult = new FinalTimeResult();
            string PathToCreateFile = @"/Users/piotr/Desktop/Git/primary/20181218/Regex.Task.2/Regex.Task.2/Result.txt";

            if (!File.Exists(PathToCreateFile))
            {
                using (StreamWriter streamWriter = File.CreateText(PathToCreateFile))
                {
                    streamWriter.WriteLine("Total time: {0}", finalTimeResult.ReturnTotalTime(TotalTime));
                    streamWriter.WriteLine("{0} hours and {1} minutes", finalTimeResult.ReturnTotalHours(TotalTime), finalTimeResult.ReturnTotalMinutes(TotalTime));
                }
            }
        }
    }

}
