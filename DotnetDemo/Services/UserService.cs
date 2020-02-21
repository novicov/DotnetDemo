using System.Threading.Tasks;
using DotnetDemo.Dto;

namespace DotnetDemo.Services
{
    public class UserService : IUserService
    {
        public Task ActivateAsync(long userId)
        {
            throw new System.NotImplementedException();
        }

        public Task InactivateAsync(long userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SignInResponse> SignInAsync(SignInRequest signInModel)
        {
            throw new System.NotImplementedException();
        }
    }
}