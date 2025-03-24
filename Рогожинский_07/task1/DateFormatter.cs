namespace task1
{
    class DateFormatter
    {
        public static string FormatDate(DateTime dateTime, string pattern)
        {
            try
            {
                return dateTime.ToString(pattern);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка при форматировании даты: {ex.Message}. Используется формат по умолчанию.");
                return dateTime.ToString("yyyy-MM-dd"); // Формат по умолчанию
            }
        }
    }
}
