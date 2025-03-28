namespace task1
{
    public class Progarm
    {
        public static void Main(string[] args)
        {
            AudioPlayer player = AudioPlayer.GetInstance();

            player.Play("Never Gonna Give You Up.mp3");
            player.Stop();

            AudioPlayer anotherPlayer = AudioPlayer.GetInstance();
            Console.WriteLine(player == anotherPlayer);
        }
    }
}