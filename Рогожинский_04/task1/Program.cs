using task1;

public class Program
{
    public static void Main(string[] args)
    {
        A myClass = new A(5, 3);

        double squareDifference = myClass.SquareOfDifference();
        double calculatedExpression = myClass.CalculatindExpression();

        System.Console.WriteLine($"Квадрат разности: {squareDifference}");
        System.Console.WriteLine($"Вычисленное выражение: {calculatedExpression}");
    }
}
