using System.Net.Http.Json;
using CodeSmells.Model;

namespace CodeSmells.Repositories;

public class UserRepo : IUserRepo
{
    private readonly HttpClient _httpClient;
    private readonly string _url;

    public UserRepo(HttpClient httpClient, string url)
    {
        _httpClient = httpClient;
        _url = url;
    }

    public List<User> GetUsers()
    {
        var users = new List<User>();

        try
        {
            users = _httpClient?.GetFromJsonAsync<List<User>>(_url).Result;

            if (users == null)
                throw new NullReferenceException("Users are null");
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException(ex.Message);
        }

        return users;
    }

}