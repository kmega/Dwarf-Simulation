using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise101
{
    enum BookType { Fantasy, Other}
    class Book
    {
        public static int numberOfBooks = 0;
        public int id { get; }
        public BookType bookType;
        public bool read { get; set; }
        public Book(BookType bookType,bool read)
        {
            id = numberOfBooks;
            numberOfBooks += 1;
            this.read = read;
            this.bookType = bookType;
        }
    }
}
