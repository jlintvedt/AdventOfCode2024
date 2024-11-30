﻿using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day24Benchmark
    {
        string input;
        readonly int day = 24;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D24_P1() => Day24.Puzzle1(input);

        [Benchmark]
        public string D24_P2() => Day24.Puzzle2(input);
    }
}
