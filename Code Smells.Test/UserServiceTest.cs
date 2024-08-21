using CodeSmells.Model;
using CodeSmells.Repositories;
using CodeSmells.Services;
using Moq;
using Shouldly;

namespace CodeSmells.Test;

[TestFixture]
public class UserServiceTest
{
    private UserService _userService;
    private Mock<IUserRepo> _userRepoMock;

    [SetUp]
    public void Setup()
    {
        _userRepoMock = new Mock<IUserRepo>();
        _userService = new UserService(_userRepoMock.Object);
    }

    [Test]
    public void GetUsers_WhenUsersIsNotEmpty_ShouldReturnUsers()
    {
        var expectedUsers = new List<User>{
            new User { id = 1, name = "John", company = "Microsoft" },
            new User { id = 2, name = "Jane", company = "Google" },
            new User { id = 3, name = "Jack", company = "Apple" }
        };

        _userRepoMock.Setup(repo => repo.GetUsers()).Returns(expectedUsers);

        var result = _userService.GetUsers();

        result.ShouldNotBe(Enumerable.Empty<User>());
        result.Count.ShouldBe(expectedUsers.Count);
        _userRepoMock.Verify(repo => repo.GetUsers(), Times.Once());
    }

    [Test]
    public void GetUsers_WhenUsersIsEmpty_ShouldReturnEmptyList()
    {
        _userRepoMock.Setup(repo => repo.GetUsers()).Returns([]);

        var result = _userService.GetUsers();

        result.ShouldBe(Enumerable.Empty<User>());
        result.Count.ShouldBe(0);
    }

    [Test]
    public void GetUsers_WhenUsersIsNull_ShouldThrowNullReferenceException()
    {
        _userRepoMock.Setup(repo => repo.GetUsers()).Throws(new NullReferenceException());

        Should.Throw<NullReferenceException>(() => _userService.GetUsers());
    }

    [Test]
    public void GetUsers_WhenRepoThrowsHttpRequestException_ShouldThrowHttpRequestException()
    {
        _userRepoMock.Setup(repo => repo.GetUsers()).Throws(new HttpRequestException());

        Should.Throw<HttpRequestException>(() => _userService.GetUsers());
    }
}