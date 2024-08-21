using CodeSmells.Model;

namespace CodeSmells.Repositories;

public interface IUserRepo
{
    List<User> GetUsers();
}