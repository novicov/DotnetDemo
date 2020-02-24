using System;
using System.Threading.Tasks;
using Domain;
using Repository.DB;

namespace Repository.User
{
    public class UserRepository : EfRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserEntity> FindByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}