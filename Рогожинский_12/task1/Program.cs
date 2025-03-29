namespace task1
{
    public class Program
    {
        static void PlayMedia(MediaFactory factory)
        {
            IMediaFile mediaFile = factory.CreateMedia();
            Console.WriteLine(mediaFile.Play());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Создание и воспроизведение аудио:");
            PlayMedia(new AudioFactory());

            Console.WriteLine("\nСоздание и воспроизведение видео:");
            PlayMedia(new VideoFactory());

            Console.WriteLine("\nСоздание и отображение изображения:");
            PlayMedia(new ImageFactory());
        }
    }
}