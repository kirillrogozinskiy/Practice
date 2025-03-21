public class Program
{
    public static void Main(string[] args)
    {
        int[] intArray = { 1, 2, 3, 4, 5 };
        double intAverage = CalcAverSum(intArray);
        Console.WriteLine($"Среднее значение intArray: {intAverage}");

        double[] doubleArray = { 1.5, 2.5, 3.5 };
        double doubleAverage = CalcAverSum(doubleArray);
        Console.WriteLine($"Среднее значение doubleArray: {doubleAverage}");

        object[] mixedArray = { "1", 2, "3.5", 4, "invalid" };
        double mixedAverage = CalcAverSum(mixedArray);
        Console.WriteLine($"Среднее значение mixedArray: {mixedAverage}");

        string[] stringArray = { "10", "20", "invalid", "30" };
        double stringAverage = CalcAverSum(stringArray);
        Console.WriteLine($"Среднее значение stringArray: {stringAverage}");

        int[] emptyArray = { };
        double emptyAverage = CalcAverSum(emptyArray);
        Console.WriteLine($"Среднее значение emptyArray: {emptyAverage}");

        int[] nullArray = null;
        double nullAverage = CalcAverSum(nullArray);
        Console.WriteLine($"Среднее значение nullArray: {nullAverage}");
    }

    public static double CalcAverSum<T>(T[] array) 
    {
        if (array == null || array.Length == 0)
        {
            return 0;
        }
        double sum = 0;
        foreach (var number in array)
        {
            if (number != null && double.TryParse(number.ToString(), out double result))
            {
                sum += result;
            }
        }
        return sum / array.Length;  
    }
}