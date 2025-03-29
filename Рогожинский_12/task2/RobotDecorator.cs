namespace task2
{
    public abstract class RobotDecorator : IRobot
    {
        protected IRobot Robot;

        public RobotDecorator(IRobot robot)
        {
            Robot = robot;
        }

        public virtual string GetStatus()
        {
            return Robot.GetStatus();
        }
    }
}
