namespace task6
{
    class WeekDayChecker
    {
        public static string SelectWeekDay(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                    return "Понедельник";
                case 2:
                    return "Вторник";
                case 3:
                    return "Среда";
                case 4:
                    return "Четверг";
                case 5:
                    return "Пятница";
                case 6:
                    return "Суббота";
                case 7:
                    return "Воскресенье";
                default:
                    return $"Дня под порядковым номером {dayNumber} не существует.";
            }
            
        }
    }
}
