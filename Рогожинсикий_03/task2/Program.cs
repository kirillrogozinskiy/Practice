public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите натуральное число n: ");
        int arrLenght = int.Parse(Console.ReadLine());

        int[] arrayNumbers = new int[arrLenght];
        Random random = new Random();

        Console.WriteLine("Сформированный массив:");
        for (int i = 0; i < arrLenght; i++)
        {
            arrayNumbers[i] = random.Next(-10, 11);
        }

        Console.WriteLine(string.Join(" ,", arrayNumbers));

        int positiveSum = 0;
        int negativeCount = 0;
        int zeroCount = 0;

        foreach(int number in arrayNumbers)
        {
            if (number > 0)
            {
                positiveSum += number;
            }
            else if (number < 0)
            {
                negativeCount++;
            }
            else
            {
                zeroCount++;
            }
        }

        Console.WriteLine($"Сумма положительных элементов: {positiveSum}");
        Console.WriteLine($"Количество отрицательных элементов: {negativeCount}");
        Console.WriteLine($"Количество нулевых элементов: {zeroCount}");

        Array.Sort(arrayNumbers);

        Console.WriteLine("Отсортированный массив:");
        Console.WriteLine(string.Join(" ,", arrayNumbers));

        Console.WriteLine("Введите K для поиска: ");
        int k = int.Parse(Console.ReadLine());

        int index = Array.BinarySearch(arrayNumbers, k);

        if (index >= 0)
        {
            Console.WriteLine($"Число {k} находится под индексом {index}.");
        }
        else
        {
            Console.WriteLine($"Число {k} не найдено.");
        }
    }
}