int number = 123;

int firstDigit = number / 100;
int lastDigit = number % 100;

int result = lastDigit * 10 + firstDigit;

Console.WriteLine($"Исходное число: {number}");
Console.WriteLine($"Полученное число: {result}");