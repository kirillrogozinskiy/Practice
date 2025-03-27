namespace task2
{
    public class TransactionFileWriter
    {
        private const string FileName = "file.data";

        public void AddTransaction(Transaction transaction)
        {
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(transaction.ToString());
            }
        }
    }
}
