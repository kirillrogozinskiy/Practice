namespace task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();
            DisplayPanel displayPanel = new DisplayPanel();
            WarningSystem warningSystem = new WarningSystem();

            WeatherMonitor weatherMonitor = new WeatherMonitor(weatherStation, displayPanel, warningSystem);

            weatherStation.ChangeWeather(25, 60, 10); 
            weatherStation.ChangeWeather(30, 70, 60); 
        }
    }
}