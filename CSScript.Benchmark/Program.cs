using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ISB.Runtime;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using MoonSharp.Interpreter;
using Neo.IronLua;

namespace CSScript.Benchmark
{
    public class SumBenchmark
    {
        [Benchmark]
        public void NoeLuaSum()
        {
            using (var lua = new Lua())
            {
                const string source =
       @"
local sum = 0.0
for i = 1, 10000000 do
    sum = sum + i
end
print(sum)
";
                var chunk = lua.CompileChunk(source, "sum.lua", null);
                var global = lua.CreateEnvironment();
                global.DoChunk(chunk);
            }
        }

        [Benchmark]
        public void MoonSharpSum()
        {
            string source = @"    
local sum = 0.0
for i = 1, 10000000 do
    sum = sum + i
end
print(sum)
";
            Script.RunString(source);
        }

        [Benchmark]
        public void ISBSum()
        {
            const string source =
@"
sum = 0
for i = 1 to 10000000
    sum = sum + i
endfor
print(sum)
";

            Engine engine = new Engine("");
            if (!engine.Compile(source, true))
            {
                Console.WriteLine("Compile error.");
            }
            if (!engine.Run(true))
            {
                Console.WriteLine("Run error.");
            }
            if (engine.StackCount > 0)
            {
                Console.WriteLine(engine.StackTop.ToDisplayString());
            }
        }

        [Benchmark]
        public void CSScriptSum()
        {
            Func<Task> task = async () =>
            {
                var script = await CSharpScript.RunAsync(
    @"
using System;

static class MyClass
{
    public static void Sum()
    {
        var sum = 0.0;
        for (int i = 0; i <= 10000000; ++i)
        {
            sum = sum + i;
        }
        Console.WriteLine(sum);
    }
}");
                await script.ContinueWithAsync("MyClass.Sum();");
            };
            task().Wait();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SumBenchmark>();
        }
    }
}
