namespace task2
{
    public class VoiceControlDecorator : RobotDecorator
    {
        public VoiceControlDecorator(IRobot robot) : base(robot)
        {
        }

        public override string GetStatus()
        {
            return base.GetStatus() + "\n- Голосовое управление: активировано";
        }
    }
}
