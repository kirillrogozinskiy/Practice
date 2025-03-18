using System.Data;

namespace task8
{
    class NumberSequenceProcessor
    {
        public static bool IsCorrectInput(int a, int b)
        {
            if (a >= 1 && a <= 100 && b <= 100 && b >= 1 && a < b)
            {
                return true;
            }
            return false;
        }

        public static (List<int>, int) FindNumbersRange(int a, int b)
        {
            if (!IsCorrectInput(a, b))
            {
                throw new ArgumentException("Некорректный ввод. Условия: 1 <= A, B <= 100 и A < B");
            }

            List<int> numbers = new List<int>();

            for (int i = a; i <= b; i++)
            {
                numbers.Add(i);
            }

            int count = numbers.Count;

            return (numbers, count);
        }

        public static void PrintNumbersRange(int a, int b)
        {
            (List<int> numbers, int count) = FindNumbersRange(a, b);

            Console.WriteLine("Числа от A до B в порядке возрастания:");

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine(); 
            Console.WriteLine($"Количество чисел (N): {count}");
        }
    }
}
