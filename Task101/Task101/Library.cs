using System;
using System.Collections.Generic;
using System.Linq;

namespace Task101
{
    public class Library
    {
        public List<Book> Books;
        public Library()
        {
            Books = new List<Book>()
            {
                new Book("LOTR", false, BookCategory.Fantasy),
                new Book("Room 1801", false, BookCategory.Horror),
                new Book("Zero", false, BookCategory.Criminal),
                new Book("The Witcher", false, BookCategory.Fantasy),
                new Book("Gothic", true, BookCategory.Fantasy)
            };
        }
        public List<Book> FilterBooksByCategory(BookCategory bookCategory)
        {
            var filteredBooks = Books.Where(x => x.Category == bookCategory)
                                .ToList();
            return filteredBooks;
        }
        public List<Book> RemoveAllReadBooks(List<Book> books)
        {
            var notReadBooks = books.Where(x => x.IsFinished == false)
                                    .ToList();
            return notReadBooks;
        }
        public Book PickRandomBook(List<Book> books)
        {
            Random rand = new Random();
            int index = rand.Next(books.Capacity-2);
            return books.ElementAt(index);
        }
    }
}
