namespace task7
{
    class NumberCubeCalculator
    {
        public static bool IsCorrectInput(int a, int b)
        {
            if (a <= b)
            {
                return true;
            }
            return false;
        }

        public static List<long> CalculateCubeWhile(int a, int b)
        {
            List<long> cubes = new List<long>();

            if (!IsCorrectInput(a, b))
            {
                throw new ArgumentException("B должно быть больше или равно A.");
            }

            int i = b;
            while (i >= a)
            {
                cubes.Add((long)Math.Pow(i, 3));
                i--;
            }

            return cubes;
        }

        public static List<long> CalculateCubeDoWhile(int a, int b)
        {
            List<long> cubes = new List<long>();

            if (!IsCorrectInput(a, b))
            {
                throw new ArgumentException("B должно быть больше или равно A.");
            }

            int i = b;
            if (i >= a)
            {
                do
                {
                    cubes.Add((long)Math.Pow(i, 3));
                    i--;
                } while (i >= a);
            }

            return cubes;
        }

        public static List<long> CalculateCubeFor(int a, int b)
        {
            List<long> cubes = new List<long>();

            if (!IsCorrectInput(a, b))
            {
                throw new ArgumentException("B должно быть больше или равно A.");
            }

            for (int i = b; i >= a; i--)
            {
                cubes.Add((long)Math.Pow(i, 3));
            }

            return cubes;
        }

        public static void PrintCubes(List<long> cubes)
        {
            Console.WriteLine("Кубы чисел в обратном порядке:");
            foreach (long cube in cubes)
            {
                Console.WriteLine(cube);
            }
        }
    }
}
