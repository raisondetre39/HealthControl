using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IIndicatorValuesRepository
    {
        Task<AddIndicatorValueStatus> InsertAsync(IndicatorValue entity);

        Task<bool> IsDeviceIndicatorExist(int deviceIndicatorId);
    }
}
