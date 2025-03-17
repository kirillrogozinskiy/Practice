try
{
    Console.Write("a = ");
    int a = int.Parse(Console.ReadLine());

    Console.Write("b = ");
    int b = int.Parse(Console.ReadLine());

    int result = a * b;
    Console.WriteLine($"{a} * {b} = {result}");
   
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: Некорректный формат ввода. Введите целое число.");
}
