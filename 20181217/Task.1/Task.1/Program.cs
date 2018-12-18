namespace Task
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CompareBooks cb = new CompareBooks();
            cb.DisplayUnRead();
            cb.ReadAndPutIntoReadBooks();
        }
    }
}
