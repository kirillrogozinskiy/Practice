/*
 Описать процедуру AddRightDigit(D, K), добавляющую к целому положительному
числу K справа цифру D (D — входной параметр целого типа, лежащий в
диапазоне 0–9, K — параметр целого типа, являющийся одновременно входным и
выходным). С помощью этой процедуры последовательно добавить к данному
числу K справа данные цифры D1 и D2, выводя результат каждого добавления.
 */
public class Program
{
    public static void Main(string[] args)
    {
        int number = 123;
        int digit1 = 4;
        int digit2 = 5;

        AddRightDigit(digit1, ref number);
        Console.WriteLine($"После добавления {digit1}: {number}"); 

        AddRightDigit(digit2, ref number);
        Console.WriteLine($"После добавления {digit2}: {number}"); 

        AddRightDigit(10, ref number); 
    }
    public static void AddRightDigit(int d, ref int k)
    {
        if(d >= 0 && d <= 9)
        {
            k = k * 10 + d;
        }
        else
        {
            Console.WriteLine("D — входной параметр целого типа, лежащий в диапазоне 0–9"); ;
        }
    }
}