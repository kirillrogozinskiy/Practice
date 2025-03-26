namespace task1
{
    public enum Direction
    {
        Up,
        Down,
        None
    }
    public class ElevatorRequest
    {
        public int Floor { get; set; }
        public Direction Direction { get; set; }

        public ElevatorRequest(int floor, Direction direction)
        {
            Floor = floor;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"Этаж {Floor}. Направление {Direction}";
        }
    }
}
