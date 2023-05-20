using FakeItEasy;
using System.Linq.Expressions;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() =>  userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
                .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancellationSource.Token);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();
            IUserService userService = new UserManager(userRepositoryMock);
            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("Dilara", "Demirhan", 24, null, cancellationSource.Token));
            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("Ada", "Lovelace", 24, String.Empty, cancellationSource.Token));
        }

        [Fact]
        public async Task AddAsync_ShouldReturn_CorrectUserId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            Guid expectedUserId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");
            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User
            {
                Id = expectedUserId
            };

            A.CallTo(() => userRepositoryMock.AddAsync(expectedUser, cancellationSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);

            Guid userId = await userService.AddAsync("Dilara", "Demirhan", 24, "dilara@gmail.com", cancellationSource.Token);

            Assert.Equal(expectedUserId, userId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            Guid userId = Guid.NewGuid();

            var cancellationSource = new CancellationTokenSource();

            A.CallTo(() => userRepositoryMock.DeleteAsync(A<Expression<Func<User, bool>>>.Ignored, cancellationSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);
            var result = await userService.DeleteAsync(userId, cancellationSource.Token);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();
            IUserService userService = new UserManager(userRepositoryMock);
            await Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteAsync(Guid.Empty, cancellationSource.Token));
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {

        }



    }
}
