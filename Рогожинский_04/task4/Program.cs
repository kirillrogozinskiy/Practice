namespace task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("Война и мир", "Л.Н. Толстой", 1225, "Роман"),
                new Book("Краткая история времени", "Стивен Хокинг", 256, "Наука"),
                new Book("Мастер и Маргарита", "М.А. Булгаков", 448, "Роман")
            };

            Library library = new Library(books);

            Book longestBook = library.GetLongestBook();
            Console.WriteLine($"Самая длинная книга: {longestBook.Title}");

            Book[] romanBooks = library.GetBooksByGenre("Роман");
            Console.WriteLine("Книги жанра 'Роман':");
            foreach (Book book in romanBooks)
            {
                Console.WriteLine($"- {book.Title}");
            }
        }
    }
}