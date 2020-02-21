using System.Threading.Tasks;
using Domain;
using DotnetDemo.Dto;
using DotnetDemo.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Repository.DB;
using Repository.User;
using Xunit;

namespace DotnetDemo.Test
{
    public class UserTests
    {
        static UserTests()
        {
            var serviceCollection = new ServiceCollection();

            // serviceCollection.AddInMemoryDatabase("test_users");
            var mockContext = new Mock<DatabaseContext>();
            serviceCollection.AddSingleton(mockContext);

            var testUser = new UserEntity(1, Login, "Новиков", "Антон", "Сергеевич", true);

            var mockedRepository = new Mock<IUserRepository>();

            mockedRepository
                .Setup(x => x.GetByIdAsync(1))
                .Returns(Task.FromResult(testUser));

            mockedRepository
                .Setup(x => x.FindByLoginAsync(Login))
                .Returns(Task.FromResult(testUser));

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped(provider => mockedRepository.Object);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            UserService = ServiceProvider.GetRequiredService<IUserService>();
        }

        protected static ServiceProvider ServiceProvider { get; }
        private static readonly IUserService UserService;
        private const string Login = "@True0";
        private static IUserRepository UserRepository => ServiceProvider.GetRequiredService<IUserRepository>();

        [Fact]
        public async Task ActivateAsync()
        {
            var user = await UserRepository.FindByLoginAsync(Login);
            await UserService.ActivateAsync(user.Id);
            var response = await UserRepository.GetByIdAsync(user.Id);
            var result = response == null || !response.IsActive;
            result.Should().BeFalse();
        }

        [Fact]
        public async Task InactivateAsync()
        {
            var user = await UserRepository.FindByLoginAsync(Login);
            await UserService.InactivateAsync(user.Id);
            var response = await UserRepository.GetByIdAsync(user.Id);
            var result = response == null || response.IsActive;
            result.Should().BeFalse();
        }

        [Fact]
        public async Task SignInAsync()
        {
            var request = new SignInRequest
            {
                Login = Login,
                Password = "test"
            };
            var response = await UserService.SignInAsync(request);
            var result = response?.AccessToken;
            result.Should().NotBeNullOrEmpty();
        }
    }
}