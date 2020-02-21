using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.DB;

namespace DotnetDemo.Test.Database
{
    public class InMemoryDatabaseContext : DatabaseContext
    {
        public InMemoryDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(builder => { builder.Ignore(x => x.NotUserField); });
        }
    }
}