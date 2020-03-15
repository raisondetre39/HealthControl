using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using System.Threading.Tasks;

namespace ControlSystem.BL.Device.Services
{
    public interface IIndicatorValuesService
    {
        Task<AddIndicatorValueStatus> AddIndicatorValue(IndicatorValue indicatorValue);
    }
}
