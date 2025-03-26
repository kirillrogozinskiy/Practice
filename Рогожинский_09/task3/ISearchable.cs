namespace task3
{
    public interface ISearchable<T>
    {
        T Find(IEnumerable<T> items, Func<T, bool> predicate);
    }
}
