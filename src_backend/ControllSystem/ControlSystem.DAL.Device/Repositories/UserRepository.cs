using ControlSystem.DAL.Device.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> IsUserExist(int id)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var any = await context.Users.AnyAsync(s => s.Id == id);
                return any;
            }
        }
    }
}
