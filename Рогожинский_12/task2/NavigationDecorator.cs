namespace task2
{
    public class NavigationDecorator : RobotDecorator
    {
        public NavigationDecorator(IRobot robot) : base(robot)
        {
        }

        public override string GetStatus()
        {
            return base.GetStatus() + "\n- Улучшенная навигация: GPS и картография активны";
        }
    }
}
