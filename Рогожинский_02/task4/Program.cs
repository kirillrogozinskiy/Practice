namespace task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите значение x: ");
                double x = double.Parse(Console.ReadLine());

                double y = FunctionCalculator.CalculateFunction(x);
                Console.WriteLine($"Значение функции y: {y}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введено некорректное число.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}