namespace task3
{
    public class Television
    {
        private bool isOn = false;
        private int volume = 50;

        public void PowerOn()
        {
            if (!isOn)
            {
                isOn = true;
                Console.WriteLine("Телевизор включен");
            }
        }

        public void PowerOff()
        {
            if (isOn)
            {
                isOn = false;
                Console.WriteLine("Телевизор выключен");
            }
        }

        public void IncreaseVolume()
        {
            if (isOn && volume < 100)
            {
                volume++;
                Console.WriteLine($"Громкость увеличена до {volume}");
            }
            else if (!isOn)
            {
                Console.WriteLine("Телевизор выключен - нельзя изменить громкость");
            }
        }

        public void DecreaseVolume()
        {
            if (isOn && volume > 0)
            {
                volume--;
                Console.WriteLine($"Громкость уменьшена до {volume}");
            }
            else if (!isOn)
            {
                Console.WriteLine("Телевизор выключен - нельзя изменить громкость");
            }
        }
    }
}
