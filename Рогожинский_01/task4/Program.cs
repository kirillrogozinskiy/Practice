int a = 1;
int b = 2;
int c = 3;

double x0 = -b / (2 * a);

double y0 = a * x0 * x0 + b * x0 + c;

Console.WriteLine("Координаты вершины параболы:");
Console.WriteLine("x0 = " + x0);
Console.WriteLine("y0 = " + y0);