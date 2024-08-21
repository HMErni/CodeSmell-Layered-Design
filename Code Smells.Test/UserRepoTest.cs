using CodeSmells.Model;
using CodeSmells.Repositories;
using Moq;
using Shouldly;

namespace CodeSmells.Test;

[TestFixture]
public class UserRepoTest
{
    private Mock<IUserRepo> _userRepoMock;

    [SetUp]
    public void Setup()
    {
        _userRepoMock = new Mock<IUserRepo>();
    }

    [Test]
    public void GetUsers_WhenHttpClientReturnsUsers_ShouldReturnUsers()
    {
        // Arrange
        var expectedUsers = new List<User>{
            new User { id = 1, name = "John", company = "Microsoft" },
            new User { id = 2, name = "Jane", company = "Google" },
            new User { id = 3, name = "Jack", company = "Apple" }
        };

        _userRepoMock.Setup(repo => repo.GetUsers()).Returns(expectedUsers);

        // Act
        var result = _userRepoMock.Object.GetUsers();

        // Assert
        result.Count.ShouldBe(expectedUsers.Count);
        _userRepoMock.Verify(repo => repo.GetUsers(), Times.Once());
    }

    [Test]
    public void GetUsers_WhenHttpClientReturnsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.GetUsers()).Returns([]);

        // Act
        var result = _userRepoMock.Object.GetUsers();

        // Assert
        result.ShouldBe(Enumerable.Empty<User>());
        result.Count.ShouldBe(0);
        _userRepoMock.Verify(repo => repo.GetUsers(), Times.Once());
    }

    [Test]
    public void GetUsers_ThrowsNullException_ShouldThrowException()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.GetUsers()).Throws(new NullReferenceException());

        // Act & Assert
        Should.Throw<NullReferenceException>(() => _userRepoMock.Object.GetUsers());
    }

    [Test]
    public void GetUsers_ThrowsHttpRequestException_ShouldThrowException()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.GetUsers()).Throws(new HttpRequestException());

        // Act & Assert
        Should.Throw<HttpRequestException>(() => _userRepoMock.Object.GetUsers());
    }
}