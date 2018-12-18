namespace Task2
{
    class FinalTimeResult
    {

        public int ReturnTotalHours(int TotalTime)
        {
           return TotalTime / 60;
        }

        public int ReturnTotalMinutes(int TotalTime)
        {
            return TotalTime % 60;
        }

        public int ReturnTotalTime(int TotalTime)
        {
            return TotalTime;
        }

        public void DisplaySums(int TotalTime)
        {
            System.Console.WriteLine("Total time: {0}", ReturnTotalTime(TotalTime));
            System.Console.WriteLine("{0} hours and {1} minutes", ReturnTotalHours(TotalTime), ReturnTotalMinutes(TotalTime));
        }

    }
}