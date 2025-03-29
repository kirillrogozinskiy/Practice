namespace task3
{
    public class VolumeUpCommand : ICommand
    {
        private Television tv;

        public VolumeUpCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.IncreaseVolume();
        }
    }
}
