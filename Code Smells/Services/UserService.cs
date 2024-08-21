using System.Net.Http.Json;
using CodeSmells.Model;
using CodeSmells.Repositories;

namespace CodeSmells.Services;

public class UserService
{
    private readonly IUserRepo _userRepo;
    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public List<User> GetUsers()
    {
        var users = _userRepo.GetUsers();

        return users;

    }
}