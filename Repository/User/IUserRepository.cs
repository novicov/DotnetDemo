using System.Linq;
using Domain;
using Repository.DB;

namespace Repository.User
{
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
    }
}