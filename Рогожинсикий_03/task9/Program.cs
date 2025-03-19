using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder("Hello, world!");
        string prefix1 = "Hello";
        string prefix2 = "hello";
        string prefix3 = "World";

        Console.WriteLine($"'{sb}' начинается с '{prefix1}': {StartsWith(sb, prefix1)}"); 
        Console.WriteLine($"'{sb}' начинается с '{prefix2}': {StartsWith(sb, prefix2)}"); 
        Console.WriteLine($"'{sb}' начинается с '{prefix3}': {StartsWith(sb, prefix3)}"); 
    }

    public static bool StartsWith(StringBuilder sb, string prefix)
    {
        return sb.ToString().StartsWith(prefix);
    }
}
