namespace task2
{
    public class ThreeDigitNumberChecker
    {
        private int number;

        public ThreeDigitNumberChecker(int number)
        {
            this.number = number;
        }

        public bool IsSumOfDigitsEven()
        {
            if (!IsThreeDigitNumber())
            {
                throw new ArgumentException("Число должно быть трехзначным.");
            }

            int sum = CalculateSumOfDigits();
            return sum % 2 == 0;
        }

        private bool IsThreeDigitNumber()
        {
            return number >= 100 && number <= 999;
        }

        private int CalculateSumOfDigits()
        {
            int sum = 0;
            int temp = number;
            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }
            return sum;
        }
    }
}
