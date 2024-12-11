# AdventOfCode2024

### Running benchmarks
Update reference [BenchmarkRunner.Run<Day**17**Benchmark>(config)](AdventOfCodeBenchmark/Program.cs).

Run without debugger: `ctrl+f5` in VS Code. This stores the benchmark in [results](AdventOfCodeBenchmark\BenchmarkDotNet.Artifacts\results) folder and the [Results](Results.json) file, also updates the table below.

## Runtimes
<!--ResultTableStart-->
|                                |         | Test @4.5GHz<sup>1</sup> | Benchmark<sup>2</sup> |
|--------------------------------|---------|-------------------------:|----------------------:|
| [Day01](AdventOfCode/Day01.cs) | Puzzle1 |                     <1ms |                  65μs |
|                                | Puzzle2 |                     <1ms |                  77μs |
| [Day02](AdventOfCode/Day02.cs) | Puzzle1 |                     <1ms |                 152μs |
|                                | Puzzle2 |                     <1ms |                 196μs |
| [Day11](AdventOfCode/Day11.cs) | Puzzle1 |                      2ms |                 275μs |
|                                | Puzzle2 |                     34ms |                  10ms |
<!--ResultTableEnd-->

1) AMD Ryzen 7 7700X @ 4.5GHz. Visual Studio Test Explorer
2) AMD Ryzen 7 7700X @ 4.5GHz. Using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet).