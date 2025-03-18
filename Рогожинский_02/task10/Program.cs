namespace task10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите число n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n <= 0)
                {
                    Console.WriteLine("Введите положительное целое число.");
                }
                else
                {
                    int divisorCount = DivisorCounter.CountDivisors(n);
                    Console.WriteLine($"Количество делителей числа {n}: {divisorCount}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите целое число.");
            }
        }
    }
}