namespace MartianRobots.Test
{
    using MartianRobots.Cli;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    [TestClass]
    public class CliTests
    {
        [TestMethod]
        [DynamicData(nameof(Test.Data), typeof(Test))]
        public void Cli_works(string input, string expected)
        {
            using (var reader = new StringReader(input))
            {
                Console.SetIn(reader);

                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    Program.Main();

                    var actual = writer.ToString();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
