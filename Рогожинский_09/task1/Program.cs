namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ElevatorSystem elevator = new ElevatorSystem();

            elevator.AddRequest(3, Direction.Up); 
            elevator.AddRequest(5, Direction.None); 
            elevator.AddRequest(2, Direction.Down); 

            elevator.ProcessRequests();
        }
    }
}