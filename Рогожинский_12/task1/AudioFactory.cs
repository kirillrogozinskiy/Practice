namespace task1
{
    public class AudioFactory : MediaFactory
    {
        public override IMediaFile CreateMedia()
        {
            return new AudioFile();
        }
    }
}
