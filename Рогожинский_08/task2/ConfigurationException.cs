namespace task2
{
    class ConfigurationException : Exception
    {
        public ConfigurationException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
