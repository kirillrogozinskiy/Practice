namespace task3
{
    public class SearchManager<T>
    {
        public ISearchable<T> Searcher;

        public SearchManager(ISearchable<T> searcher)
        {
            Searcher = searcher;
        }

        public T Search(IEnumerable<T> items, Func<T, bool> predicate)
        {
            return Searcher.Find(items, predicate);
        }


        public void DisplaySearchResult(T item)
        {
            if (item == null)
            {
                Console.WriteLine("Элемент не найден.");
            }
            else
            {
                Console.WriteLine($"Найденный элемент: {item}"); 
            }
        }

        public void SearchAndDisplay(IEnumerable<T> items, Func<T, bool> predicate)
        {
            T result = Search(items, predicate);
            DisplaySearchResult(result);
        }
    }
}
