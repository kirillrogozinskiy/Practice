namespace task3
{
    public class SimpleSearch<T> : ISearchable<T>
    {
        public T Find(IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null)
            {
                return default; 
            }

            return items.FirstOrDefault(predicate);
        }
    }
}
