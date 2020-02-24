using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Repository.DB;

namespace DotnetDemo.Test.Database
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection serviceCollection,
            string databaseName)
        {
            var options = CreateInMemoryDatabaseOption(databaseName);
            serviceCollection
                .AddEntityFrameworkInMemoryDatabase()
                .AddScoped<DatabaseContext>(provider => new InMemoryDatabaseContext(options));

            return serviceCollection;
        }

        private static DbContextOptions CreateInMemoryDatabaseOption(string databaseName)
        {
            return new DbContextOptionsBuilder<DatabaseContext>()
                .AddInterceptors()
                .UseInMemoryDatabase(databaseName: databaseName)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }
    }
}