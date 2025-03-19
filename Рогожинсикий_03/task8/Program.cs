public class Program
{
    public static void Main(string[] args)
    {
        string[] inputs = { "123,45", "-12.3", "abc", "123", "123." };

        foreach (string input in inputs)
        {
            Console.WriteLine($"{input} - {IsDoubleNumber(input)}");
        }
    }

    public static bool IsDoubleNumber(string inputString)
    {
        try
        {
            Convert.ToDouble(inputString);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}