using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository.DB
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        private DatabaseContext()
        {
        }


        /// <summary>
        ///     Пользователи
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}