namespace task1
{
    delegate string TimeHandler(DateTime dateTime, string pattern);
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string dateFormat = "MM/dd/yyyy";
            string timeFormat = "HH:mm:ss";
            string invalidFormat = "MMMMMM/dd/yyyy"; 

            TimeHandler dateFormatterDelegate = DateFormatter.FormatDate;
            string formattedDate = dateFormatterDelegate(now, dateFormat);
            Console.WriteLine($"Отформатированная дата: {formattedDate}");

            formattedDate = dateFormatterDelegate(now, invalidFormat);
            Console.WriteLine($"Отформатированная дата (с неверным форматом): {formattedDate}"); 

            TimeHandler timeFormatterDelegate = TimeFormatter.TimeFormat;
            string formattedTime = timeFormatterDelegate(now, timeFormat);
            Console.WriteLine($"Отформатированное время: {formattedTime}");
        }
    }
}
