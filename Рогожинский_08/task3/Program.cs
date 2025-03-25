namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TemperatureSensor sensor = new TemperatureSensor();

            try
            {
                sensor.SetTemperature(25);   
                sensor.SetTemperature(-60);  
            }
            catch (TemperatureOutOfRangeException ex) 
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}