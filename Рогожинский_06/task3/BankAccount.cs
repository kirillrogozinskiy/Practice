namespace task3
{
    class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}, Баланс: {Balance}");
        }
    }
}
