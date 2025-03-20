namespace task2
{
    public static class ArrayOperations
    {
        public static T[] SortArray<T>(T[] array) where T : IComparable<T>
        {
            T[] sortedArray = (T[])array.Clone();
            Array.Sort(sortedArray);
            return sortedArray;
        }

        public static T[] FilterArray<T>(T[] array, Func<T, bool> predicate)
        {
            return array.Where(predicate).ToArray();
        }

        public static double CalculateAverage(double[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            return array.Average();
        }

        public static int CalculateSum(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            return array.Sum();
        }

        public static double[] GenerateRandomDoubleArray(int size, double minValue, double maxValue)
        {
            Random random = new Random();
            double[] array = new double[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = minValue + (maxValue - minValue) * random.NextDouble();
            }
            return array;
        }

        public static int[] GenerateRandomIntArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }

        public static double Product(double[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 1;
            }
            double product = 1;
            foreach (double num in array)
            {
                product *= num;
            }
            return product;
        }
    }
}
