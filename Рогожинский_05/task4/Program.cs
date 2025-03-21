using task4;

public class Program
{
    public static void Main(string[] args) 
    {
        string str1 = "12345";
        string str2 = "12345abc";
        string str3 = "";

        Console.WriteLine($"'{str1}' состоит только из цифр: {str1.IsDigitsOnly()}"); 
        Console.WriteLine($"'{str2}' состоит только из цифр: {str2.IsDigitsOnly()}"); 
        Console.WriteLine($"'{str3}' состоит только из цифр: {str3.IsDigitsOnly()}"); 
    }
}