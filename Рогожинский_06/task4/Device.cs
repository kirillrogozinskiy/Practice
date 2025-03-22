namespace task4
{
    class Device: IPowerOff, IPowerOn
    {
            private bool IsOn = false;

            void IPowerOn.TogglePower()
            {
                IsOn = true;
                Console.WriteLine("Устройство включено (через IPowerOn).");
            }

            void IPowerOff.TogglePower()
            {
                IsOn = false;
                Console.WriteLine("Устройство выключено (через IPowerOff).");
            }

            public void ShowStatus()
            {
                Console.WriteLine($"Устройство в состоянии: {(IsOn ? "Включено" : "Выключено")}");
            }
        }
}
