namespace UnitTestProject1
{
    internal class RightCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            robot.Orientation -= 90;
        }
    }
}
