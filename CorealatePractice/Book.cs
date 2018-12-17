using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorealatePractice
{
    enum BookType
    {
        FANTASY, OTHER
    }

    class Book
    {
        string bookTitle;
        BookType bookType;
        bool isRead;
        

        public Book(string bookTitle, BookType bookType, bool isRead )
        {
            this.bookTitle = bookTitle;
            this.isRead = isRead;
            this.bookType = bookType;
        }

        public static void ShowBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine("Tytuł książki: {0}, typ ksiązki {1}, przeczytana: {2}", book.bookTitle, book.bookType, book.isRead);
            }
        }

        public static Book SearchBookAndRead(List<Book> books) {
            foreach (var book in books)
            {
                if(book.bookType == BookType.FANTASY && book.isRead == false) {
                    book.isRead = true;
                    return book;
                }
            } return null;
        }
    }
}
