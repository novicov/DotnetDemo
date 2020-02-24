using System;
using System.Threading.Tasks;
using DotnetDemo.Dto;
using Repository.User;

namespace DotnetDemo.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task ActivateAsync(long userId)
        {
            var userEntity = await _userRepository.GetByIdAsync(userId);
            userEntity.Activate();
            await _userRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task InactivateAsync(long userId)
        {
            var userEntity = await _userRepository.GetByIdAsync(userId);
            userEntity.Inactivate();
            await _userRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<SignInResponse> SignInAsync(SignInRequest signInModel)
        {
            var user = await _userRepository.FindByLoginAsync(signInModel.Login);
            if (user == null) throw new Exception("User Not Exist");
            if (!user.IsActive) throw new Exception("User Deactivated");
            // Verify Password, Attempts Count

            // generate access token
            var accToken = new SignInResponse(Guid.NewGuid().ToString());
            return accToken;
        }
    }
}