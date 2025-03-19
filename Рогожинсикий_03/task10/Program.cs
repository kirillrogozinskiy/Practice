using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        string text = "Hello,   world!  123";

        Console.WriteLine($"Исходная строка: '{text}'");
        Console.WriteLine($"Строка с одним пробелом: '{ReplaceSpaces(text)}'");
    }
    public static string ReplaceSpaces(string inputString)
    {
        return Regex.Replace(inputString, @"\s+", " ");
    }
}