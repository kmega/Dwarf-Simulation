using System.Collections.Generic;

namespace Task
{
    class BooksFile
    {
        public List<Book> ReadBooks = new List<Book>
        {
            {new Book("fantasy", "title 1")},
            {new Book( "horror", "title 2")},
            {new Book("fantasy", "title 4")}
        };

        public List<Book> AllBooks = new List<Book>
        {
            {new Book("fantasy", "title 1")},
            {new Book( "horror", "title 2")},
            {new Book("fantasy", "title 4")},
            {new Book("fantasy", "title 31")},
            {new Book( "romans", "title 51")},
            {new Book("fantasy", "title 61")}
        };
    }


}
