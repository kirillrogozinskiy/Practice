namespace task2
{
    public class Transaction
    {
        public int Id;
        public decimal Amount { get; }

        public Transaction(int id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Id}|{Amount}";
        }
    }
}
