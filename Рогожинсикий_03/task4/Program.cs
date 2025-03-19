public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите количество строк массива: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов массива: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] array = new int[rows, cols];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = random.Next(-10, 11); 
            }
        }

        Console.WriteLine("Массив:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }

        Console.Write("Введите номер столбца: ");
        int columnNumber = int.Parse(Console.ReadLine()) - 1; 
        
        if (columnNumber < 0 || columnNumber >= cols)
        {
            Console.WriteLine("Некорректный номер столбца.");
            return;
        }
        
        Console.Write("Введите число для проверки кратности: ");
        int divisor = int.Parse(Console.ReadLine());

        

        int columnSum = 0;
        for (int i = 0; i < rows; i++)
        {
            columnSum += array[i, columnNumber];
        }

        if (columnSum % divisor == 0)
        {
            Console.WriteLine($"Сумма элементов столбца {columnNumber + 1} кратна числу {divisor}.");
        }
        else
        {
            Console.WriteLine($"Сумма элементов столбца {columnNumber + 1} не кратна числу {divisor}.");
        }
    }
}