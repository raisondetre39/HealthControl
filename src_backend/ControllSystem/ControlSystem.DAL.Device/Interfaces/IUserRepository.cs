using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUserExist(int id);
    }
}
