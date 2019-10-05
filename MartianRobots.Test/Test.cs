namespace MartianRobots.Test
{
    using System.Collections.Generic;

    public static class Test
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
    }
}