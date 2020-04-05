using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IUserRepository
    {
        Task<Contracts.Entities.User> IsUserExist(int id);
    }
}
