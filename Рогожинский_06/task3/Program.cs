namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount[] accounts = new BankAccount[]
            {
            new SavingsAccount("1", 1000),
            new LoanAccount("2", 500, 5000, 0.05m),
            new SavingsAccount("3", 2000),
            new LoanAccount("4", 1000, 10000, 0.08m)
            };

            Console.WriteLine("\nКредитные счета:");
            var creditAccounts = accounts.Where(account => account is ICreditAccount).Cast<ICreditAccount>(); 
            foreach (var account in creditAccounts)
            {
                ((BankAccount)account).GetInfo();  
            }

            Console.WriteLine("\nИспользование методов интерфейсов:");
            foreach (var account in accounts)
            {
                if (account is IDebitAccount debitAccount)
                {
                    debitAccount.Deposit(100);
                }

                if (account is IDebitAccount debitAccountWithdraw)
                {
                    debitAccountWithdraw.Withdraw(50);
                }

                if (account is ICreditAccount creditAccount)
                {
                    creditAccount.ChargeInterest();
                }
            }

            Console.ReadKey();
        }
    }
}