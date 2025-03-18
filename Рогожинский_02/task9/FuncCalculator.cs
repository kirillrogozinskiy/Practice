namespace task9
{
    public class FuncCalculator
    {
        public static double[] CalculateFunction(double a, double b, int m)
        {
            double h = (b - a) / m;
            double[] results = new double[m + 1];

            for (int i = 0; i <= m; i++)
            {
                double x = a + i * h;
                results[i] = Math.Acos(x);
            }

            return results;
        }

        public static void PrintResults(double a, double b, int m)
        {
            Console.WriteLine($"Значения функции Arccos(x) на отрезке [{a}, {b}]:");

            double[] results = CalculateFunction(a, b, m);

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"F(x) = {results[i]:F4}");
            }
        }
    }
}
