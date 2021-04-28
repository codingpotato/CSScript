using Neo.IronLua;

namespace CSScript.Shell
{
    internal static class NeoLua
    {
        internal static void Run()
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
    }
}
