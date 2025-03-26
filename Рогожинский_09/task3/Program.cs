namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<int> numbers = new List<int> { 1, 3, 5, 7, 9, 11, 13, 15 };

            
            SearchManager<int> searchManager = new SearchManager<int>(new SimpleSearch<int>());

            Console.WriteLine("Поиск четного числа:");
            searchManager.SearchAndDisplay(numbers, x => x % 2 == 0);

            Console.WriteLine("Поиск числа больше 10:");
            searchManager.SearchAndDisplay(numbers, x => x > 10);

            Console.WriteLine("Поиск числа 7:");
            searchManager.SearchAndDisplay(numbers, x => x == 7);

            List<string> names = new List<string> { "Анна", "Борис", "Владимир", "Галина" };

            SearchManager<string> stringSearchManager = new SearchManager<string>(new SimpleSearch<string>());

            Console.WriteLine("Поиск имени длиной 5 символов:");
            stringSearchManager.SearchAndDisplay(names, s => s.Length == 5);

            Console.WriteLine("Поиск имени, начинающегося на 'Г':");
            stringSearchManager.SearchAndDisplay(names, s => s.StartsWith("Г"));
        }
    }
}