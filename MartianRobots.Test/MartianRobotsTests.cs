namespace MartianRobots.Test
{
    using MartianRobots;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class MartianRobotsTests
    {
        [TestMethod]
        [DynamicData(nameof(Test.Data), typeof(Test))]
        public void Sample_data_is_correct(string input, string expected)
        {
            var world = Parser.Parse(input);
            world.Execute();
            var actual = Serialiser.Serialise(world);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Unkown_command_throws()
        {
            const string input = @"1 1
0 0 W
X";

            Sample_data_is_correct(input, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Unkown_orientation_throws()
        {
            const string input = @"1 1
0 0 X
F";

            Sample_data_is_correct(input, string.Empty);
        }
    }
}
