namespace task5
{
    class ThreeDigitNumberChecker
    {
        public static bool IsCorrectInput(int number)
        {
            if (number >= 100 && number <= 999)
            {
                return true;
            }
            return false;
        }

        public static bool IsDigitEqual(int number)
        {
            if (!IsCorrectInput(number))
            {
                throw new ArgumentException("Число должно быть трехзначным.");
            }

            int digit1 = number / 100;
            int digit2 = (number / 10) % 10;
            int digit3 = number % 10;

            return digit1 == digit2 && digit2 == digit3;
        }
    }
}
