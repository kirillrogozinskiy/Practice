namespace task4
{
    public class DisplayPanel
    {
        public void UpdateDisplay(double temperature, double humidity, double windSpeed)
        {
            Console.WriteLine($"[DisplayPanel] Температура: {temperature}°C, Влажность: {humidity}%, Скорость ветра: {windSpeed} км/ч");
        }
    }
}
