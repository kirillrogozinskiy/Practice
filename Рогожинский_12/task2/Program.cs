namespace task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRobot robot = new BasicRobot();
            Console.WriteLine(robot.GetStatus());

            Console.WriteLine("\nДобавляем голосовое управление:");
            robot = new VoiceControlDecorator(robot);
            Console.WriteLine(robot.GetStatus());

            Console.WriteLine("\nДобавляем улучшенную навигацию:");
            robot = new NavigationDecorator(robot);
            Console.WriteLine(robot.GetStatus());

            Console.WriteLine("\nДобавляем дополнительные датчики:");
            robot = new SensorDecorator(robot);
            Console.WriteLine(robot.GetStatus());


        }
    }
}
