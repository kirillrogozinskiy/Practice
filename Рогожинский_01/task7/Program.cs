public class Program
{
    public static void Main(string[] args)
    {
        double[] test = { 4, 5, -4, -5 };

        foreach (double x in test)
        {
            double z1 = CalculateZ1(x);
            double z2 = CalculateZ2(x);

            Console.WriteLine($"x = {x}");
            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}");
            Console.WriteLine();
        }
    }

    public static double CalculateZ1(double x)
    {
        double numerator = Math.Pow(x, 2) + 2 * x - 3 + (x + 1) * Math.Sqrt(Math.Pow(x, 2) - 9);
        double denominator = Math.Pow(x, 2) - 2 * x - 3 + (x - 1) * Math.Sqrt(Math.Pow(x, 2) - 9);
        return numerator / denominator;
    }

    public static double CalculateZ2(double x)
    {
        return Math.Sqrt((x + 3) / (x - 3));
    }
}