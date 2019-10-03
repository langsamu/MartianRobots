namespace UnitTestProject1
{
    internal abstract class Command
    {
        internal abstract void Execute(Robot robot, World world);

        internal static Command Parse(char command)
        {
            // TODO: enum
            switch (command)
            {
                case 'L':
                    return new LeftCommand();

                case 'R':
                    return new RightCommand();

                default:
                case 'F':
                    return new ForwardCommand();
            }
        }
    }
}
