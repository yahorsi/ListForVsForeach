using BenchmarkDotNet.Running;

namespace ListForVsForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LoopOverArrayOfBytes>();
        }
    }
}
