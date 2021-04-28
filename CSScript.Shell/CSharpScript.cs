using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace CSScript.Shell
{
    internal class CSScript
    {
        internal static async void Run()
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
        }
    }
}
