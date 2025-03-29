namespace task3
{
    public class TVPowerOffCommand : ICommand
    {
        private Television tv;

        public TVPowerOffCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.PowerOff();
        }
    }
}
