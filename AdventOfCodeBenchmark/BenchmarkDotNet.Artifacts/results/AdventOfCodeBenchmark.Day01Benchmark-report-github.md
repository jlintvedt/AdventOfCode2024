```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
AMD Ryzen 7 7700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI DEBUG [AttachedDebugger]
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method | N      | Mean     | Error    | StdDev   |
|------- |------- |---------:|---------:|---------:|
| D01_P1 | 100000 | 65.68 μs | 0.988 μs | 0.924 μs |
| D01_P2 | 100000 | 77.78 μs | 0.990 μs | 0.926 μs |
