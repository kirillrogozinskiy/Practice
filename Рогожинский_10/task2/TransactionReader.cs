namespace task2
{
    public class TransactionReader
    {
        private const string FileName = "file.data";

        public static List<Transaction> ReadTransactions()
        {
            List<Transaction> result = new List<Transaction>();

            using (StreamReader reader = new StreamReader(FileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    string[] parts = line.Split('|');
                    if (parts.Length != 2) 
                    {
                        Console.WriteLine("Неверный формат данных");
                    }
                    if (int.TryParse(parts[0], out int id) &&
                        decimal.TryParse(parts[1], out decimal amount))
                    {
                        result.Add(new Transaction(id, amount));
                    }
                }
            }
            return result;
        }
    }
}
