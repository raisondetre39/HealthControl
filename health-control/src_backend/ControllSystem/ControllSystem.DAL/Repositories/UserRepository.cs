using ControlSystem.Contracts.Entities;
using ControlSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserByAsync(Expression<Func<User, bool>> expression)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Users.FirstOrDefaultAsync(expression);
            }
        }
    }
}
