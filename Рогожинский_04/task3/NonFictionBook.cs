namespace task3
{
    public sealed class NonFictionBook : Book
    {
        public string Topic { get; set; }

        public NonFictionBook(string title, string author, int pages, string topic) : base(title, author, pages)
        {
            Topic = topic;
        }
    }
}
