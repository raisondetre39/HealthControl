using ControlSystem.Contracts.Responses;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IDeviceRepository
    {
        Task UpdateAsync(Contracts.Entities.Device entity);

        Task<CreateDeviceResult> InsertAsync(Contracts.Entities.Device entity);

        Task<Contracts.Entities.Device> GetDeviceByAsync(Expression<Func<Contracts.Entities.Device, bool>> expression);
    }
}
