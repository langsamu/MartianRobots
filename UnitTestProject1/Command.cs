namespace UnitTestProject1
{
    using System;

    internal abstract class Command
    {
        internal abstract void Execute(Robot robot, World world);

        internal static Command Parse(char command)
        {
            switch (command)
            {
                case 'L':
                    return new LeftCommand();

                case 'R':
                    return new RightCommand();

                case 'F':
                    return new ForwardCommand();

                default:
                    throw new Exception();
            }
        }
    }
}
