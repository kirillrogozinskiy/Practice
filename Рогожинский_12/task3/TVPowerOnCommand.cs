namespace task3
{
    public class TVPowerOnCommand : ICommand
    {
        private Television tv;

        public TVPowerOnCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.PowerOn();
        }
    }
}
