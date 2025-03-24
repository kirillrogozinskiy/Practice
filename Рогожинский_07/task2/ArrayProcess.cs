namespace task2
{
    class ArrayProcess
    {
        public delegate T[] ArrayProcessor<T>(T[] array) where T : IComparable<T>;

        public static T[] ProcessArray<T>(T[] array, ArrayProcessor<T> processor) where T : IComparable<T>
        {
            return processor(array);
        }

        public static T[] SortAscending<T>(T[] array) where T: IComparable<T>
        {
            return array.OrderBy(x => x).ToArray();
        }

        public static T[] SortDescending<T>(T[] array) where T: IComparable<T>
        {
            return array.OrderByDescending(x => x).ToArray();
        }
    }
}
