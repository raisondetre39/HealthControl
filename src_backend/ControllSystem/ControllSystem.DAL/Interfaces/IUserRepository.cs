using ControlSystem.Contracts.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByAsync(Expression<Func<User, bool>> expression);
    }
}
