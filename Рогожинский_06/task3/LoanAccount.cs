namespace task3
{
    class LoanAccount: BankAccount, ICreditAccount
    {
        public decimal CreditLimit { get; set; }
        public decimal InterestRate { get; set; }

        public LoanAccount(string accountNumber, decimal balance, decimal creditLimit, decimal interestRate) : base(accountNumber, balance)
        {
            CreditLimit = creditLimit;
            InterestRate = interestRate;
        }

        public void ChargeInterest()
        {
            decimal interest = Balance * InterestRate;
            Balance += interest;
            Console.WriteLine($"Счет {AccountNumber}:");
            Console.WriteLine($"Начислены проценты: {interest}. Новый баланс: {Balance}");
        }

        public override void GetInfo()
        {
            Console.WriteLine("Кредитный счет:");
            base.GetInfo();
            Console.WriteLine($"Кредитный лимит: {CreditLimit}, Процентная ставка: {InterestRate}");
        }
    }
}
