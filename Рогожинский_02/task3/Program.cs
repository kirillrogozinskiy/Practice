using task3;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int a = 3;
            int b = 6;

            long result = NumberSequenceCalculator.CalculateProductOfSequence(a, b);
            Console.WriteLine($"Произведение чисел от {a} до {b}: {result}");

            a = 7;
            b = 4;
            result = NumberSequenceCalculator.CalculateProductOfSequence(a, b);
            Console.WriteLine($"Произведение чисел от {a} до {b}: {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}