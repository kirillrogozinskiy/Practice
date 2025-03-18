namespace task3
{
    class NumberSequenceCalculator
    {
        public static bool IsCorrectInput(int a, int b)
        {
            if (a < 1 || a > 10 || b < 1 || b > 10 || a >= b)
            {
                return false;
            }
            return true;
        }

        public static long CalculateProductOfSequence(int a, int b)
        {
            if (!IsCorrectInput(a, b))
            {
                throw new ArgumentException("Некорректный ввод. Услови: 1 <= A, B <= 10 и A < B");
            }

            long product = 1;
            for (int i = a; i <= b; i++)
            {
                product *= i;
            }

            return product;
        }
    }
}
