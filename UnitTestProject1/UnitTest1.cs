namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"
5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL
";

            var world = Parser.Parse(input);
            world.Execute();

            var actual = Serialiser.Serialise(world);

            var expected = @"
1 1 E
3 3 N LOST
2 3 S
".Trim();

            Assert.AreEqual(expected, actual);
        }
    }
}
