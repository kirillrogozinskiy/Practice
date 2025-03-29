namespace task3
{
    public class TVRemote
    {
        private ICommand powerOn;
        private ICommand powerOff;
        private ICommand volumeUp;
        private ICommand volumeDown;

        public TVRemote(
            ICommand powerOn,
            ICommand powerOff,
            ICommand volumeUp,
            ICommand volumeDown)
        {
            this.powerOn = powerOn;
            this.powerOff = powerOff;
            this.volumeUp = volumeUp;
            this.volumeDown = volumeDown;
        }

        public void PressPowerOn() => powerOn.Execute();
        public void PressPowerOff() => powerOff.Execute();
        public void PressVolumeUp() => volumeUp.Execute();
        public void PressVolumeDown() => volumeDown.Execute();
    }
}
