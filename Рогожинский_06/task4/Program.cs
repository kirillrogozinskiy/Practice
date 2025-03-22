namespace task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Device myDevice = new Device();

            IPowerOn powerOn = myDevice;
            IPowerOff powerOff = myDevice;

            Console.WriteLine("Изначальное состояние:");
            myDevice.ShowStatus();

            Console.WriteLine("\nВызов TogglePower через IPowerOn:");
            powerOn.TogglePower(); 
            myDevice.ShowStatus(); 

            Console.WriteLine("\nВызов TogglePower через IPowerOff:");
            powerOff.TogglePower(); 
            myDevice.ShowStatus(); 
        }
    }
}