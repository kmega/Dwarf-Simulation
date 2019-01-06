using System;

namespace HappyPathsWithTests
{
    public class Task2
    {
        public void Displayresults()
        {
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\cybermagic\karty-postaci";
            string preForm = "Wszystkie postacie do tej pory budowane były {0} godzin {1} minut";

            int summaryTime = new Methods().GetSummaryTime(path);

            Console.WriteLine("### Task 2");
            Console.WriteLine(preForm, summaryTime/60, summaryTime % 60);
            Console.WriteLine();

            new FileOps().SaveToFile(@"..\Results\Result2.txt", summaryTime / 60, summaryTime % 60, preForm);
        }
    }
}