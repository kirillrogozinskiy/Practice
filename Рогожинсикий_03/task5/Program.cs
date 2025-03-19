public class Program
{
    public static void Main(string[] args)
    {
        int[][] originalArray = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6, 7 },
            new int[] { 8, 9 }
        };

        int[][] mirroredArray = MirrorArray(originalArray);

        Console.WriteLine("Начальный массив:");
        PrintArray(originalArray);

        Console.WriteLine("Отзеркаленный массив:");
        PrintArray(mirroredArray);
    }
    public static int[][] MirrorArray(int[][] array)
    {
        int[][] mirroredArray = new int[array.Length][];

        for (int i = 0; i < array.Length; i++)
        {
            mirroredArray[i] = array[array.Length - 1 - i];
        }
        return mirroredArray;
    }
    public static void PrintArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}