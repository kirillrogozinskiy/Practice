public class Program
{
    public static void Main(string[] args)
    {
        string inputString = "Hello World! 123";
        string changedCase = ChangeCase(inputString);
        Console.WriteLine($"Исходная строка: {inputString}");
        Console.WriteLine($"Строка с измененным регистром: {changedCase}");
    }
    public static string ChangeCase(string inputString)
    {
       
        char[] chars = inputString.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLower(chars[i]))
            {
                chars[i] = char.ToUpper(chars[i]);
            }
            else if (char.IsUpper(chars[i]))
            {
                chars[i] = char.ToLower(chars[i]);
            }
        }

        return new string(chars);
    }
}