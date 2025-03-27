/*
Классы:
1. Transaction – модель (Id, Amount).
2. TransactionFileWriter – записывает Transaction в file.data.
Методы TransactionFileWriter:
AppendTransaction(Transaction transaction) – добавляет запись без удаления
предыдущих данных.
*/
namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            TransactionFileWriter writer = new TransactionFileWriter();

            writer.AddTransaction(new Transaction(1, 100.50m));
            writer.AddTransaction(new Transaction(2, 200.75m));
            writer.AddTransaction(new Transaction(3, 300.25m));

            using (StreamReader reader = new StreamReader("file.data"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
            
            Console.WriteLine("Добавляем новую транзакцию...");
            writer.AddTransaction(new Transaction(4, 400.99m));
            
            Console.WriteLine("Все транзакции после добавления новой:");
            using (StreamReader reader = new StreamReader("file.data"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            Console.WriteLine("Все транзакции с суммой выше 210:");
            Console.WriteLine(string.Join("\n", TransactionProcessor.FilterByAmount(210)));
        }
    }
}