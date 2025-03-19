public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        int sum = 0;
        foreach(int number in numbers)
        {
            if (number % 3 == 0)
            {
                sum += number;
            }
        }

        Console.WriteLine($"Сумма чисел кратных трем: {sum}");
    }
}