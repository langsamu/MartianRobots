namespace MartianRobots
{
    internal class RightCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            robot.Orientation -= 90;
        }
    }
}
