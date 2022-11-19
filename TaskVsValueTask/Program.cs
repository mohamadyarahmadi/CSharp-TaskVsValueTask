using BenchmarkDotNet.Running;
using TaskVsValueTask.Services;

namespace TaskVsValueTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}