
using MoonSharp.Interpreter;

namespace CSScript.Shell
{
    internal static class MoonSharp
    {
        internal static void Run()
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
    }
}
