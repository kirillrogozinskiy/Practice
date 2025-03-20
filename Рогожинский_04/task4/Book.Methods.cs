namespace task4
{
    public partial class Book
    {
        public string GetInfo()
        {
            return $"{Title} ({Author}), {Pages} стр., Жанр: {Genre}";
        }
    }
}
