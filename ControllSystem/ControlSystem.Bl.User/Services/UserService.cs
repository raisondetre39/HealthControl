using ControlSystem.BL.User.Helpers;
using ControlSystem.BL.User.Interfaces;
using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.User.Interfaces;
using ControlSystem.Middleware.Auth;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.BL.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationManager _authenticationManager;

        public UserService(
            IUnitOfWork unitOfWork,
            IAuthenticationManager authenticationManager)
        {
            _userRepository = unitOfWork.UserRepository;
            _authenticationManager = authenticationManager;
        }

        public async Task<Contracts.Entities.User> GetUserBy(Expression<Func<Contracts.Entities.User, bool>> expression)
        {
            return await _userRepository.GetUserByAsync(expression);
        }

        public async Task<CreateUserResponse> CreateUser(Contracts.Entities.User user)
        {
            user.Password = user.Password.GetCryptedString();
            var result = await _userRepository.InsertAsync(user);

            if (result.Status != CreateUserStatus.Success)
                return result;
            
            _authenticationManager.GenerateToken(user,out string token);

            result.Token = token;

            return result;
        }

        public async Task<UpdateUserStatus> UpdateUser(Contracts.Entities.User user)
        {
            user.Password = user.Password.GetCryptedString();
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<IEnumerable<Contracts.Entities.User>> GetUsers()
        {
            return await _userRepository.GetAsync(); 
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
