using System;
using ISB.Runtime;

namespace CSScript.Shell
{
    internal static class ISB
    {
        internal static void Run()
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
    }
}
