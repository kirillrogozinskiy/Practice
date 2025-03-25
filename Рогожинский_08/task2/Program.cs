namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ConfigurationManager configManager = new ConfigurationManager();
                configManager.LoadConfiguration(@"D:\Education\С#\Практика\Рогожинский_08\task2\con.json");
                configManager.LoadConfiguration(@"D:\Education\С#\Практика\Рогожинский_08\task2");
            }
            catch (ConfigurationException ex)
            {
                Console.WriteLine($"Произошла ошибка конфигурации: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }
    }
}
