namespace task7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = 2;
            int b = 5;

            NumberCubeCalculator.PrintCubes(NumberCubeCalculator.CalculateCubeWhile(a, b));
            NumberCubeCalculator.PrintCubes(NumberCubeCalculator.CalculateCubeDoWhile(a, b));
            NumberCubeCalculator.PrintCubes(NumberCubeCalculator.CalculateCubeFor(a, b));
        }
    }
}