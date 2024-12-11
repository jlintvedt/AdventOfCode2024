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
            readonly List<Stone> stones = [];

            public PlutonianPebbles(string input)
            {
                foreach (var num in input.Split(' '))
                    stones.Add(new Stone(long.Parse(num)));
            }

            public long CountNumberOfStonesAfterBlinks(int blinks)
            {
                for (int i = 0; i < blinks; i++)
                    Blink();

                return stones.Count;
            }

            private void Blink()
            {
                var numNewStones = 0;
                var newStones = new List<(int pos, Stone stone)>();

                for (int i = 0; i < stones.Count; i++)
                {
                    var newStone = stones[i].Change();
                    if (newStone != null)
                        newStones.Add((i + ++numNewStones, newStone));
                }

                foreach (var (pos, stone) in newStones)
                    stones.Insert(pos, stone);
            }

            public class Stone(long number)
            {
                public long Number = number;

                public Stone Change()
                {
                    if (Number == 0)
                    {
                        Number = 1;
                        return null;
                    }

                    // Check if even number of digits and split stone
                    var digits = Math.Floor(Math.Log10(Number)) + 1;
                    if (digits % 2 == 0)
                    {
                        var mask = (long)Math.Pow(10, digits/2);
                        var remainder = Number % mask;
                        Number = (Number - remainder) / mask;
                        return new Stone(remainder);
                    }

                    // Multiply number
                    Number *= 2024;
                    return null;
                }

                public override string ToString()
                {
                    return Number.ToString();
                }
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
            return "Puzzle2";
        }
    }
}
