using Domain;
using Repository.DB;

namespace Repository.User
{
    public class UserRepository : EfRepository<UserEntity>, IUserRepository
    {
        protected UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}