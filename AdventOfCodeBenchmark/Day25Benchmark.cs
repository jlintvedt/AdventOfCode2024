﻿using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day25Benchmark
    {
        string input;
        readonly int day = 25;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D25_P1() => Day25.Puzzle1(input);

        [Benchmark]
        public string D25_P2() => Day25.Puzzle2(input);
    }
}
