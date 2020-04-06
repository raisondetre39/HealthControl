using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.User.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteAsync(int id);

        Task<IEnumerable<Contracts.Entities.User>> GetAsync();

        Task<UpdateUserStatus> UpdateAsync(Contracts.Entities.User entity);

        Task<CreateUserResponse> InsertAsync(Contracts.Entities.User entity);

        Task<Contracts.Entities.User> GetUserByAsync(Expression<Func<Contracts.Entities.User, bool>> expression);

    }
}
