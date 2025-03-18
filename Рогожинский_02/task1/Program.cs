using task1;

public class Program
{
    static void Main(string[] args)
    {
        Square mySquare = new Square(5.0);

        double perimeter = mySquare.GetPerimetr();

        Console.WriteLine($"Периметр квадрата равен: {perimeter}");
    }
}