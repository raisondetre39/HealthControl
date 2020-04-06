using System.Threading.Tasks;

namespace ControlSystem.DAL.User.Interfaces
{
    public interface IDiseaseRepository
    {
        Task<bool> IsDiseaseExist(int id);
    }
}
