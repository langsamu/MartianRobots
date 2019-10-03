namespace UnitTestProject1
{
    internal class LeftCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            robot.Orientation += 90;
        }
    }
}
