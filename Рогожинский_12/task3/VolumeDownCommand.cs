namespace task3
{
    public class VolumeDownCommand : ICommand
    {
        private Television tv;

        public VolumeDownCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.DecreaseVolume();
        }
    }
}
