namespace task3
{
    interface ICreditAccount
    {
        decimal CreditLimit { get; set; }
        decimal InterestRate { get; set; }
        void ChargeInterest();
    }
}
