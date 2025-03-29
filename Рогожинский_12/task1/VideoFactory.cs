namespace task1
{
    public class VideoFactory : MediaFactory
    {
        public override IMediaFile CreateMedia()
        {
            return new VideoFile();
        }
    }
}
