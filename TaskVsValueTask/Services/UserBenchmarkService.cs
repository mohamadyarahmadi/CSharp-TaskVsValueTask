using BenchmarkDotNet.Attributes;

namespace TaskVsValueTask.Services;

[MemoryDiagnoser]
public class UserBenchmarkService
{
    [Benchmark]
    public async Task RunTask()
    {
        var userService = new UserService();
        var userNames = new string[] { "mohamad", "hasan", "hoseyn","moslem" };
        for (int i = 0; i < 100; i++)
        {
            foreach (var userName in userNames)
            {
                var repo = await userService.GetUsersAsyncTask(userName);
            }
        }
    }

    [Benchmark]
    public async Task RunValueTask()
    {
        var userService = new UserService();
        var userNames = new string[] { "mohamad", "hasan", "hoseyn", "moslem" };
        for (int i = 0; i < 100; i++)
        {
            foreach (var userName in userNames)
            {
                var repo = await userService.GetUsersAsyncValueTask(userName);
            }
        }
    }
}