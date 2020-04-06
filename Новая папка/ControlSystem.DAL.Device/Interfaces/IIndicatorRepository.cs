using ControlSystem.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IIndicatorRepository
    {
        Task<bool> IsIndicatorsExist(IEnumerable<int> indicators);

        Task<IEnumerable<Indicator>> GetIndicators();
    }
}
