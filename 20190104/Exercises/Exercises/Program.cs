namespace Exercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartTasks start = new StartTasks();
            string[] teaData = start.FindTeaData();
            start.ReverseRecords(teaData);
        }
    }
}