double x = 2;
Console.WriteLine($"x = {x}");

double part1 = Math.Tan(Math.Sqrt(Math.Log(Math.Pow(Math.E, x + 1))));
double part2 = (3 + Math.Sin(x * x)) / (Math.Sin(x * x) - Math.Cos(x * x));

double y = part1 - part2;

Console.WriteLine($"y = {y}");