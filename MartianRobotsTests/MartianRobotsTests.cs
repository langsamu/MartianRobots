namespace MartianRobotsTests
{
    using MartianRobots;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
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

                yield return new[] {
                    @"1 1
0 0 S
F",
                    @"0 0 S LOST"
                };

                yield return new[] {
                    @"1 1
1 0 W
F",
                    @"0 0 W"
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
