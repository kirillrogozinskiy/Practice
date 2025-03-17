Console.WriteLine("Вычисление площади треугольника.");
Console.WriteLine("Введите исходные данные:");

try
{
    Console.Write("Основание (см): ");
    double length = double.Parse(Console.ReadLine());

    Console.Write("Высота (см): ");
    double height = double.Parse(Console.ReadLine());

    double area = (length * height) / 2;
    Console.WriteLine($"Площадь треугольника: {area}");
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: Некорректный формат ввода. Введите числовые значения.");
}