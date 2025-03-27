namespace task2
{
    public class TransactionProcessor
    {
        public static IEnumerable<Transaction> FilterByAmount(decimal minAmount)
        {
            List<Transaction> transaction = TransactionReader.ReadTransactions();
            return  transaction.Where(t => t.Amount > minAmount);
        }
    }
}
