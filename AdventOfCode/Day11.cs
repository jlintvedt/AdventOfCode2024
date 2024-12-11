using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2024/day/11
    /// </summary>
    public class Day11
    {
        public class PlutonianPebbles
        {
            Dictionary<long, long> stones = [];

            public PlutonianPebbles(string input)
            {
                foreach (var num in input.Split(' '))
                    AddStones(stones, long.Parse(num), 1);
            }

            public long CountNumberOfStonesAfterBlinks(int blinks)
            {
                for (int i = 0; i < blinks; i++)
                    Blink();

                long count = 0;
                foreach (var stone in stones)
                    count += stone.Value;

                return count;
            }

            private void Blink()
            {
                var tmpStones = new Dictionary<long, long>();

                foreach (var (value, count) in stones)
                {
                    var changed = ChangeStone(value);
                    AddStones(tmpStones, changed.Item1, count);
                    if (changed.Item2 >= 0)
                        AddStones(tmpStones, changed.Item2, count);
                }

                stones = tmpStones;
            }

            private static void AddStones(Dictionary<long, long> stones, long value, long count)
            {
                if (!stones.TryAdd(value, count))
                    stones[value] += count;
            }

            public static (long, long) ChangeStone(long value)
            {
                if (value == 0)
                    return (1, -1);

                // Check if even number of digits and split stone
                var digits = (int)Math.Floor(Math.Log10(value)) + 1;
                if (digits % 2 == 0)
                {
                    var mask = (long)Math.Pow(10, digits / 2);
                    var remainder = value % mask;
                    value = (value - remainder) / mask;
                    return (value, remainder);
                }

                // Multiply number
                return (value * 2024, -1);
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var pp = new PlutonianPebbles(input);
            return pp.CountNumberOfStonesAfterBlinks(25).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var pp = new PlutonianPebbles(input);
            return pp.CountNumberOfStonesAfterBlinks(75).ToString();
        }
    }
}
