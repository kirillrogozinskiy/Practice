namespace task4
{
    public class WeatherStation
    {
        public event WeatherChangedEventHandler WeatherChanged;

        public void ChangeWeather(double temperature, double humidity, double windSpeed)
        {
            OnWeatherChanged(new WeatherChangedEventArgs(temperature, humidity, windSpeed));
        }

        protected virtual void OnWeatherChanged(WeatherChangedEventArgs e)
        {
            WeatherChanged?.Invoke(this, e);
        }
    }
}
