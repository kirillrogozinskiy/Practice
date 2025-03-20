namespace task3
{
    public sealed class FictionBook : Book
    {
        public string Genre { get; set; }

        public FictionBook(string title, string author, int pages, string genre) : base(title, author, pages)
        {
            Genre = genre;
        }
    }
}
