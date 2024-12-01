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

            public int CalculateTotalDistance()
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

            public long CalcultateSimilarityScore()
            {
                var left = ListToFrequencyMap(IdsLeft);
                var right = ListToFrequencyMap(IdsRight);
                long sum = 0;

                foreach (var (num, frequencyLeft) in left)
                    if (right.TryGetValue(num, out int frequencyRight))
                        sum += num * frequencyLeft * frequencyRight;

                return sum;
            }

            private Dictionary<int, int> ListToFrequencyMap(List<int> list)
            {
                var map = new Dictionary<int, int>();
                foreach (var number in list)
                {
                    if (map.ContainsKey(number))
                        map[number]++;
                    else
                        map[number] = 1;
                }

                return map;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ls = new LocationSolver(input);
            return ls.CalculateTotalDistance().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
                var ls = new LocationSolver(input);
                return ls.CalcultateSimilarityScore().ToString();
            }
    }
}
