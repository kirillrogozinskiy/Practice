Console.Write("Введите трехзначное число: ");

try
{
    int number = int.Parse(Console.ReadLine());

    if (number >= 100 && number <= 999)
    {
        int firstDigit = number / 100;
        int secondDigit = (number / 10) % 10;
        int thirdDigit = number % 10;

        int result = firstDigit + secondDigit + thirdDigit;

        Console.WriteLine($"Число: {number}, {firstDigit} + {secondDigit} + {thirdDigit} = {result}");
    }
    else
    {
        Console.WriteLine("Ошибка: Введенное число не является трехзначным.");
    }
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: Некорректный формат ввода. Введите целое число.");
}