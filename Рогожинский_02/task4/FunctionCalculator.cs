namespace task4
{
    class FunctionCalculator
    {
        public static double CalculateFunction(double x)
        {
            if (x >= 4 && x <= 6)
            {
                return x;
            }
            else if (x > 6)
            {
                return 3 * x + 4 * Math.Pow(x, 2);
            }
            else
            {
                throw new ArgumentException("Функция не определена для x < 4");
            }
        }
    }
}
