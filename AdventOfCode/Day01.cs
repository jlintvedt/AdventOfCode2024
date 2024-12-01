using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2024/day/1
    /// </summary>
    public class Day01
    {
        public class LocationSolver
        {
            List<int> IdsLeft = [];
            List<int> IdsRight = [];

            public LocationSolver(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    var parts = line.Split("   ");
                    IdsLeft.Add(int.Parse(parts[0]));
                    IdsRight.Add(int.Parse(parts[1]));
                }
            }

            public int FindTotalDistance()
            {
                var sum = 0;
                IdsLeft.Sort();
                IdsRight.Sort();

                for (int i = 0; i < IdsLeft.Count; i++)
                {
                    var diff = IdsLeft[i] - IdsRight[i];
                    sum += diff > 0 ? diff : -diff;
                }

                return sum;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ls = new LocationSolver(input);
            return ls.FindTotalDistance().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
