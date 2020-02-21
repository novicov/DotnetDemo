using System.Threading.Tasks;
using Domain;
using Repository.DB;

namespace Repository.User
{
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
        Task<UserEntity> FindByLoginAsync(string login);
    }
}