namespace task1
{
    public class ImageFactory : MediaFactory
    {
        public override IMediaFile CreateMedia()
        {
            return new ImageFile();
        }
    }
}
