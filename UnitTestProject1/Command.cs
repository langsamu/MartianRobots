namespace UnitTestProject1
{
    using System;

    internal abstract class Command
    {
        internal abstract void Execute(Robot robot, World world);

        internal static Command Parse(CommandToken command)
        {
            switch (command)
            {
                case LeftCommandToken _:
                    return new LeftCommand();

                case RightCommandToken _:
                    return new RightCommand();

                case ForwardCommandToken _:
                    return new ForwardCommand();

                default:
                    throw new Exception();
            }
        }
    }
}
