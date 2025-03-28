namespace task1
{
    public class AudioPlayer
    {
        private static AudioPlayer Instance;

        private AudioPlayer() { }

        public static AudioPlayer GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AudioPlayer();
            }
            return Instance;
        }

        public void Play(string track)
        {
            Console.WriteLine($"Играет {track}");
        } 

        public void Stop()
        {
            Console.WriteLine("Воспроизведение остановленно");
        }
    }
}
