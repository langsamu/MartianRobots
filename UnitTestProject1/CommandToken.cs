namespace UnitTestProject1
{
    using System;

    internal abstract class CommandToken
    {
        internal static CommandToken Parse(char value)
        {
            switch (value)
            {
                case 'L':
                    return new LeftCommandToken();

                case 'R':
                    return new RightCommandToken();

                case 'F':
                    return new ForwardCommandToken();

                default:
                    throw new Exception();
            }
        }
    }
}
