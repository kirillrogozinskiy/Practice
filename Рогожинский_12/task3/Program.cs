namespace task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tv = new Television();
            var remote = new TVRemote(
                new TVPowerOnCommand(tv),
                new TVPowerOffCommand(tv),
                new VolumeUpCommand(tv),
                new VolumeDownCommand(tv)
            );

            remote.PressPowerOn();       
            remote.PressVolumeUp();      
            remote.PressVolumeUp();      
            remote.PressVolumeDown();    
            remote.PressPowerOff();     
            remote.PressVolumeUp();      
        }
    }
}