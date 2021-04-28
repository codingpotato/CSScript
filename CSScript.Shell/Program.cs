namespace CSScript.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            NeoLua.Run();
            ISB.Run();
            CSScript.Run();
        }
    }
}
