public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите размер матрицы N (N < 10): ");
        int n = int.Parse(Console.ReadLine());

        if (n >= 10)
        {
            Console.WriteLine("Размер матрицы должен быть меньше 10.");
            return;
        }

        Console.Write("Введите начало диапазона a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите конец диапазона b: ");
        int b = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = random.Next(a, b + 1); 
            }
        }

        Console.WriteLine("Исходная матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        int oddProduct = 1;
        bool hasOdd = false;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] % 2 != 0)
                {
                    oddProduct *= matrix[i, j];
                    hasOdd = true;
                }
            }
        }

        if (hasOdd)
        {
            Console.WriteLine($"Произведение нечётных элементов: {oddProduct}");
        }
        else
        {
            Console.WriteLine("В матрице нет нечётных элементов.");
        }

        Console.Write("Введите номер строки k: ");
        int k = int.Parse(Console.ReadLine());

        if (k < 1 || k > n)
        {
            Console.WriteLine($"Номер строки k должен быть от 1 до {n}.");
        }
        else
        {
            int rowSum = 0;
            for (int j = 0; j < n; j++)
            {
                rowSum += matrix[k - 1, j]; 
            }
            Console.WriteLine($"Сумма элементов {k} строки: {rowSum}");
        }
    }
}