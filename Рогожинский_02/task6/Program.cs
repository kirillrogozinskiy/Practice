namespace task6{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(WeekDayChecker.SelectWeekDay(1));
            Console.WriteLine(WeekDayChecker.SelectWeekDay(4));
            Console.WriteLine(WeekDayChecker.SelectWeekDay(7));
            Console.WriteLine(WeekDayChecker.SelectWeekDay(0));
            Console.WriteLine(WeekDayChecker.SelectWeekDay(8));
        }
    }
}