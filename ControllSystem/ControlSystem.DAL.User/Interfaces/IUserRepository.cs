using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.User.Interfaces
{
    public interface IUserRepository
    {
        //Task DeleteAsync(int id);

        Task<UpdateUserStatus> UpdateAsync(Contracts.Entities.User entity);

        Task<CreateUserResponse> InsertAsync(Contracts.Entities.User entity);

        Task<Contracts.Entities.User> GetUserByAsync(Expression<Func<Contracts.Entities.User, bool>> expression);

        //Task<bool> IsUserEmailUnique(string email, int id = default(int));

        //Task<bool> IsUserExist(int id);
    }
}
