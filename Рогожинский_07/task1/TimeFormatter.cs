namespace task1
{
    class TimeFormatter
    {
        public static string TimeFormat(DateTime dateTime, string pattern)
        {
            try
            {
                return dateTime.ToString(pattern);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка при форматировании времени: {ex.Message}. Используется формат по умолчанию.");
                return dateTime.ToString("yyyy-MM-dd");
            }
        }
    }
}
