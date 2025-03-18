namespace task8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                NumberSequenceProcessor.PrintNumbersRange(3, 7);
                NumberSequenceProcessor.PrintNumbersRange(7, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}