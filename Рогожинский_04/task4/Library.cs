namespace task4
{
    public class Library
    {
        public Book[] Books { get; set; }

        public Library(Book[] books)
        {
            Books = books;
        }

        public Book GetLongestBook()
        {
            if (Books == null || Books.Length == 0)
            {
                throw new ArgumentException("Массив книг пуст или не инициализирован.");
            }

            Book longestBook = Books[0];
            for (int i = 1; i < Books.Length; i++)
            {
                if (Books[i].Pages > longestBook.Pages)
                {
                    longestBook = Books[i];
                }
            }
            return longestBook;
        }

        public Book[] GetBooksByGenre(string genre)
        {
            if (Books == null || Books.Length == 0)
            {
                throw new ArgumentException("Массив книг пуст или не инициализирован.");
            }
            if (string.IsNullOrEmpty(genre))
            {
                throw new ArgumentException("Жанр не может быть пустым или null.");
            }

            List<Book> result = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Genre == genre)
                {
                    result.Add(book);
                }
            }
            return result.ToArray();
        }
    }
}
