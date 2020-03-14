using ControlSystem.Contracts.Responses;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.BL.Device.Interfaces
{
    public interface IDeviceService
    {
        Task<CreateDeviceResult> CreateDevice(Contracts.Entities.Device device);

        Task UpdateDevice(Contracts.Entities.Device device);

        Task<Contracts.Entities.Device> GetDeviceBy(Expression<Func<Contracts.Entities.Device, bool>> expression);
    }
}
