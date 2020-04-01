using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.BL.User.Interfaces
{
    public interface IUserService
    {
        Task<Contracts.Entities.User> GetUserBy(Expression<Func<Contracts.Entities.User, bool>> expression);

        Task<CreateUserResponse> CreateUser(Contracts.Entities.User user);

        Task<UpdateUserStatus> UpdateUser(Contracts.Entities.User user);

        Task<IEnumerable<Contracts.Entities.User>> GetUsers();

        Task DeleteUser(int id);
    }
}
