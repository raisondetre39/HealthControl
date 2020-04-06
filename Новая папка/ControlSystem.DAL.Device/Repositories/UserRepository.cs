using ControlSystem.DAL.Device.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<Contracts.Entities.User> IsUserExist(int id)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Users.FirstOrDefaultAsync(s => s.Id == id);
            }
        }
    }
}
