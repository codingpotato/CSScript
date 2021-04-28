# CSScript

```shell
dotnet run -p CSScript.Shell/CSScript.Shell.csproj
```

```shell
dotnet run -p CSScript.Benchmark/CSScript.Benchmark.csproj -c Release
```

| Method      |        Mean |      Error |     StdDev |
| ----------- | ----------: | ---------: | ---------: |
| NoeLuaSum   |   121.64 ms |   0.525 ms |   0.491 ms |
| ISBSum      | 8,813.69 ms | 168.107 ms | 186.850 ms |
| CSScriptSum |    42.72 ms |   1.082 ms |   3.190 ms |

Execute time of C code is about 30ms
