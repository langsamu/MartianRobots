namespace MartianRobotsTests
{
    using MartianRobots;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class MartianRobotsTests
    {
        public static IEnumerable<object[]> Data
        {
            get
            {
                yield return new[] {
                    @"5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL",
                    @"1 1 E
3 3 N LOST
2 3 S"
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(Data))]
        public void Sample_data_is_correct(string input, string expected)
        {
            var world = Parser.Parse(input);
            world.Execute();
            var actual = Serialiser.Serialise(world);

            Assert.AreEqual(expected, actual);
        }
    }
}
