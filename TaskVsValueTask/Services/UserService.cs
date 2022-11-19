using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using TaskVsValueTask.Model;


namespace TaskVsValueTask.Services;

public class UserService
{
    private readonly IMemoryCache _cacheRepo = new MemoryCache(new MemoryCacheOptions());
    private readonly HttpClient _client = new HttpClient();

    public UserService()
    {
        _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TaskVsValueTask", "1.0"));
    }
    public async Task<UserModel> GetUsersAsyncTask(string username)
    {
        var users = _cacheRepo.Get<UserModel>(username);
        if (users is null)
        {
            var result = await _client.GetStringAsync($"https://reqres.in/api/users?page=1");
            users = JsonSerializer.Deserialize<UserModel>(result);
            _cacheRepo.Set(username, users);
        }
        return users;
    }

    public async ValueTask<UserModel> GetUsersAsyncValueTask(string username)
    {
        var users = _cacheRepo.Get<UserModel>(username);
        if (users is null)
        {
            var result = await _client.GetStringAsync($"https://reqres.in/api/users?page=1");
            users = JsonSerializer.Deserialize<UserModel>(result);
            _cacheRepo.Set(username, users);
        }
        return users;
    }
}