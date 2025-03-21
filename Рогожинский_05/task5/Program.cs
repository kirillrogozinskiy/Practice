namespace task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sphere sphere = new Sphere(5);
            Cube cube = new Cube(4);

            sphere.DisplayInfo();
            Console.WriteLine();
            cube.DisplayInfo();
        }
    }
}
