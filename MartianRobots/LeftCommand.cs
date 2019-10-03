namespace MartianRobots
{
    internal class LeftCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            robot.Orientation += 90;
        }
    }
}
