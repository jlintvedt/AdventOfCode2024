using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2024/day/2
    /// </summary>
    public class Day02
    {
        public class RednoseReports
        {
            public List<Report> Reports = [];

            public RednoseReports(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    Reports.Add(new Report(line));
                }
            }

            public int FindNumSafeReport()
            {
                var numSafe = 0;

                foreach (var report in Reports)
                    if (report.IsGraduallyChanging())
                        numSafe++;

                return numSafe;
            }

            public class Report
            {
                public List<int> Levels = [];

                public Report(string line)
                {
                    foreach (var num in line.Split(" "))
                    {
                        Levels.Add(int.Parse(num));
                    }
                }

                public bool IsGraduallyChanging()
                {
                    var prev = Levels[0];
                    var isIncreasing = prev - Levels[1] < 0 ? true : false;

                    for (int i = 1; i < Levels.Count; i++)
                    {
                        var diff = isIncreasing ? Levels[i] - prev : prev - Levels[i];

                        if (diff < 1 || diff > 3)
                            return false;

                        prev = Levels[i];
                    }

                    return true;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rr = new RednoseReports(input);
            return rr.FindNumSafeReport().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
