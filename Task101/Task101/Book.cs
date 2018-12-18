using System;

namespace Task101
{
    public class Book
    {
        public string Title { get; set; }
        public bool IsFinished { get; set; }
        public BookCategory Category { get; set; }

        public Book(string title, bool isBookFinished, BookCategory category)
        {
            Title = title;
            IsFinished = isBookFinished;
            Category = category;
        }
        public void Read(int time)
        {
            Console.WriteLine($"Book chosen to read: {Title}, time of reading {time} h");
        }
    }
}
