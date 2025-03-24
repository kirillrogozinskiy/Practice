namespace task2
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            int[] numbers = { 5, 2, 8, 1, 9, 4 };
            string[] names = { "Charlie", "Alice", "Bob", "David" };

            int[] sortedAscendingNumbers = ArrayProcess.ProcessArray(numbers, ArrayProcess.SortAscending); 
            Console.WriteLine("Отсортированный массив чисел по возрастанию: " + string.Join(", ", sortedAscendingNumbers));

 
            string[] sortedDescendingNames = ArrayProcess.ProcessArray(names, ArrayProcess.SortDescending); 
            Console.WriteLine("Отсортированный массив строк по убыванию: " + string.Join(", ", sortedDescendingNames));
        }
    }
}
