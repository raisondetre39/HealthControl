using ControlSystem.DAL.User.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlSystem.DAL.User.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        public async Task<bool> IsDiseaseExist(int id)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Diseases
                    .AnyAsync(s => s.Id == id);
            }
        }
    }
}
