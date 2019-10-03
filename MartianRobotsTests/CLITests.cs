namespace MartianRobotsTests
{
    using CLI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    [TestClass]
    public class CLITests
    {
        [TestMethod]
        public void CLI_works()
        {
            const string input = @"5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL
";

            const string expected = @"1 1 E
3 3 N LOST
2 3 S";

            using (var reader = new StringReader(input))
            {
                Console.SetIn(reader);

                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    Program.Main();

                    var actual = writer.ToString();

                    Assert.AreEqual(expected,actual);
                }
            }
        }
    }
}
