using ControlSystem.Contracts.Responses;
using System.Threading.Tasks;

namespace ControlSystem.BL.Device.Interfaces
{
    public interface IIndicatorsService
    {
        Task<GetIndicatorsResult> GetIndicators();
    }
}
