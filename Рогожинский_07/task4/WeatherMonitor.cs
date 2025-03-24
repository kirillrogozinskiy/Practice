namespace task4
{
    public class WeatherMonitor
    {
        private DisplayPanel _displayPanel;
        private WarningSystem _warningSystem;

        public WeatherMonitor(WeatherStation weatherStation, DisplayPanel displayPanel, WarningSystem warningSystem)
        {
            _displayPanel = displayPanel;
            _warningSystem = warningSystem;

            weatherStation.WeatherChanged += OnWeatherChanged;
        }

        private void OnWeatherChanged(object sender, WeatherChangedEventArgs e)
        {
            _displayPanel.UpdateDisplay(e.Temperature, e.Humidity, e.WindSpeed);

            if (e.WindSpeed > 50)
            {
                _warningSystem.IssueStormWarning(e.WindSpeed);
            }
        }
    }
}
