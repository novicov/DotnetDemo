using System.Threading.Tasks;
using Domain;
using DotnetDemo.Dto;
using DotnetDemo.Services;
using DotnetDemo.Test.Database;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Repository.DB;
using Repository.User;
using Xunit;
using Xunit.Extensions.Ordering;

namespace DotnetDemo.Test
{
    [Collection("C1"), Order(2)]
    public class UserTests
    {
        public UserTests()
        {
            var serviceCollection = new ServiceCollection();

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
            _userService = ServiceProvider.GetRequiredService<IUserService>();
        }

        private ServiceProvider ServiceProvider { get; set; }
        private readonly IUserService _userService;
        private const string Login = "@True0";

        [Fact, Order(3)]
        public async Task SignInAsync()
        {
            var request = new SignInRequest
            {
                Login = Login,
                Password = "test"
            };
            var response = await _userService.SignInAsync(request);
            var result = response?.AccessToken;
            result.Should().NotBeNullOrEmpty();
        }
    }
}