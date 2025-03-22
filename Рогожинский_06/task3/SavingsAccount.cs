namespace task3
{
    class SavingsAccount : BankAccount, IDebitAccount
    {
        public SavingsAccount(string accountNumber, decimal balance) : base(accountNumber, balance)
        {
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Счет {AccountNumber}:");
            Console.WriteLine($"Внесено {amount}. Новый баланс: {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"Счет {AccountNumber}:");

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Снято {amount}. Новый баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств.");
            }
        }

        public override void GetInfo()
        {
            Console.WriteLine("Сберегательный счет:");
            base.GetInfo();
        }
    }
}
