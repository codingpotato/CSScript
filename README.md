# CSScript

```shell
dotnet run -p CSScript.Shell/CSScript.Shell.csproj
```

```shell
dotnet run -p CSScript.Benchmark/CSScript.Benchmark.csproj -c Release
```

| Method       |        Mean |     Error |    StdDev |
| ------------ | ----------: | --------: | --------: |
| NoeLuaSum    |   125.18 ms |  2.081 ms |  2.137 ms |
| MoonSharpSum | 1,248.73 ms | 10.402 ms |  9.221 ms |
| ISBSum       | 8,458.01 ms | 39.714 ms | 33.163 ms |
| CSScriptSum  |    47.85 ms |  1.412 ms |  4.118 ms |

Execute time of C code is about 30ms
