namespace task3
{
    class TemperatureOutOfRangeException : Exception
    {
        public TemperatureOutOfRangeException(string message) : base(message)
        {
        }
    }
}
