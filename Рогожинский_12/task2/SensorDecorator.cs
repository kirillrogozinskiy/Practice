namespace task2
{
    public class SensorDecorator : RobotDecorator
    {
        public SensorDecorator(IRobot robot) : base(robot)
        {
        }

        public override string GetStatus()
        {
            return base.GetStatus() + "\n- Дополнительные датчики: температурные, влажности, движения";
        }
    }
}
