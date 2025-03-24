namespace task4
{
    public delegate void WeatherChangedEventHandler(object sender, WeatherChangedEventArgs e);

    public class WeatherChangedEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }

        public WeatherChangedEventArgs(double temperature, double humidity, double windSpeed)
        {
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
        }
    }
}
