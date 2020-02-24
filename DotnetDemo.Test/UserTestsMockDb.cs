using System;
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
    [Collection("C1"), Order(1)]
    public class UserTestsMockDb : IDisposable
    {
        public UserTestsMockDb()
        {
            var serviceCollection = new ServiceCollection();
            var dbName = Guid.NewGuid().ToString();
            serviceCollection.AddInMemoryDatabase(dbName);
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserService, UserService>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            _userService = ServiceProvider.GetRequiredService<IUserService>();
            _userRepository = ServiceProvider.GetRequiredService<IUserRepository>();
        }

        private ServiceProvider ServiceProvider { get; set; }
        private readonly IUserService _userService;
        private const string Login = "@True0";
        private const long UserId = 1;
        private readonly IUserRepository _userRepository;

        private async Task PrepareTest()
        {
            var testUser = new UserEntity(UserId, Login, "Новиков", "Антон", "Сергеевич", true);
            await _userRepository.AddAsync(testUser);
        }

        [Fact, Order(2)]
        public async Task ActivateAsync()
        {
            // Arrange
            await PrepareTest();
            
            // Act
            await _userService.ActivateAsync(UserId);

            // Assert
            var response = await _userRepository.GetByIdAsync(UserId);
            response.IsActive.Should().BeTrue();
        }

        [Fact, Order(1)]
        public async Task InactivateAsync()
        {
            // Arrange
            await PrepareTest();

            // Act
            await _userService.InactivateAsync(UserId);

            // Assert
            var response = await _userRepository.GetByIdAsync(UserId);
            response.IsActive.Should().BeFalse();
        }

        public void Dispose()
        {
            ServiceProvider.GetRequiredService<DatabaseContext>().Database.EnsureDeleted();
        }
    }
}