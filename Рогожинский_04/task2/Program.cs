using task2;

public class Program
{
    public static void Main(string[] args)
    {
        int[] intArray = ArrayOperations.GenerateRandomIntArray(10, 1, 100);
        double[] doubleArray = ArrayOperations.GenerateRandomDoubleArray(5, 0, 5);

        Console.WriteLine("Сгенерированный массив int: " + string.Join(", ", intArray));
        Console.WriteLine("Сгенерированный массив double: " + string.Join(", ", doubleArray));

        int[] sortedIntArray = ArrayOperations.SortArray(intArray);
        Console.WriteLine("Отсортированный массив int: " + string.Join(", ", sortedIntArray));

        int sum = ArrayOperations.CalculateSum(intArray);
        Console.WriteLine("Сумма элементов массива int: " + sum);

        double average = ArrayOperations.CalculateAverage(doubleArray);
        Console.WriteLine("Среднее значение массива double: " + average);

        double product = ArrayOperations.Product(doubleArray);
        Console.WriteLine("Произведение элементов массива double: " + product);

        int[] filteredArray = ArrayOperations.FilterArray(intArray, x => x > 50);
        Console.WriteLine("Отфильтрованный массив int (>50): " + string.Join(", ", filteredArray));
    }
}