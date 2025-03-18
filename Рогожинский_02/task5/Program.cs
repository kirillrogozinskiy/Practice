namespace task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int number1 = 333;
                int number2 = 123;
                int number3 = 50;

                Console.WriteLine($"{number1}: {ThreeDigitNumberChecker.IsDigitEqual(number1)}");
                Console.WriteLine($"{number2}: {ThreeDigitNumberChecker.IsDigitEqual(number2)}");
                Console.WriteLine($"{number3}: {ThreeDigitNumberChecker.IsDigitEqual(number3)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}