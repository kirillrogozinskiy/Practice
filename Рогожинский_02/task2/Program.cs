using task2;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите трехзначное число: ");
        int number = int.Parse(Console.ReadLine());

        ThreeDigitNumberChecker checker = new ThreeDigitNumberChecker(number);

        if (checker.IsSumOfDigitsEven())
        {
            Console.WriteLine("Сумма цифр четная.");
        }
        else
        {
            Console.WriteLine("Сумма цифр нечетная.");
        }
    }
}