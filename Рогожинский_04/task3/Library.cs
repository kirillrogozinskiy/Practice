namespace task3
{
    public class Library
    {
        public Book[] Books { get; set; }

        public Library(Book[] books)
        {
            Books = books;
        }

        public Book GetMostPagesBook()
        {
            if (Books == null || Books.Length == 0)
            {
                throw new ArgumentException("Массив книг пуст или не инициализирован.");
            }

            Book mostPagesBook = Books[0];
            for (int i = 1; i < Books.Length; i++)
            {
                if (Books[i].Pages > mostPagesBook.Pages)
                {
                    mostPagesBook = Books[i];
                }
            }
            return mostPagesBook;
        }

        public Book[] GetBooksByAuthor(string author)
        {
            if (Books == null || Books.Length == 0)
            {
                throw new ArgumentException("Массив книг пуст или не инициализирован.");
            }
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Имя автора не может быть пустым или null.");
            }

            List<Book> result = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Author == author)
                {
                    result.Add(book);
                }
            }
            return result.ToArray();
        }
    }
}
