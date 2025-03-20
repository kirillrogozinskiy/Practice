using task3;

public class Program
{
    public static void Main(string[] args)
    {
        Book[] books = new Book[]
        {
            new FictionBook("Война и мир", "Л.Н. Толстой", 1225, "Роман"),
            new NonFictionBook("Краткая история времени", "Стивен Хокинг", 256, "Наука"),
            new FictionBook("Мастер и Маргарита", "М.А. Булгаков", 448, "Роман"),
            new NonFictionBook("Sapiens. Краткая история человечества", "Юваль Ной Харари", 500, "История")
        };

        Library library = new Library(books);

        Book mostPagesBook = library.GetMostPagesBook();
        Console.WriteLine($"Книга с наибольшим количеством страниц: {mostPagesBook.Title} ({mostPagesBook.Pages} страниц)");

        Book[] tolstoyBooks = library.GetBooksByAuthor("Л.Н. Толстой");
        Console.WriteLine("Книги Л.Н. Толстого:");
        foreach (Book book in tolstoyBooks)
        {
            Console.WriteLine($"- {book.Title}");
        }
    }
}