public class Program
{
    public static void Main(string[] args)
    {
        string text = "Hello, world!";
        string suffix1 = "world!";
        string suffix2 = "World!";
        string suffix3 = "ld!";

        Console.WriteLine($"'{text}' заканчивается на '{suffix1}': {EndsWithSuffix(text, suffix1)}"); 
        Console.WriteLine($"'{text}' заканчивается на '{suffix2}': {EndsWithSuffix(text, suffix2)}"); 
        Console.WriteLine($"'{text}' заканчивается на '{suffix3}': {EndsWithSuffix(text, suffix3)}"); 
    }

    public static bool EndsWithSuffix(string inputString, string suffix)
    {
        return inputString.EndsWith(suffix);
    }
}