public class Program
{
    public static void Main(string[] args)
    {
        int numberToCheck = 17;
        bool isPrime = IsPrime(numberToCheck);
        Console.WriteLine($"{numberToCheck} : {isPrime}");

        numberToCheck = 18;
        isPrime = IsPrime(numberToCheck);
        Console.WriteLine($"{numberToCheck} : {isPrime}");
    }

    public static bool IsPrime(int number, int divisor = 2)
    {
        if (number <= 1) { return false; }
        if (divisor * divisor > number) { return true; }
        if (number % divisor == 0) { return false; }
            
        return IsPrime(number, divisor + 1);
    }
}