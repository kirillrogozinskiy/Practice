namespace task4
{
    public class WarningSystem
    {
        public void IssueStormWarning(double windSpeed)
        {
            Console.WriteLine($"[WarningSystem] ВНИМАНИЕ! Штормовое предупреждение! Скорость ветра: {windSpeed} км/ч");
        }
    }
}
