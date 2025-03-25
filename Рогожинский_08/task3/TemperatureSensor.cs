namespace task3
{
    class TemperatureSensor
    {
        private int Temperature;

        public void SetTemperature(int temp)
        {

            if (temp < -50 || temp > 50)
            {
                throw new TemperatureOutOfRangeException($"Температура {temp}°C выходит за допустимый диапазон [-50, 50]");
            }

            Temperature = temp;
            Console.WriteLine($"Температура установлена: {Temperature}°C");
        }
    }
}
