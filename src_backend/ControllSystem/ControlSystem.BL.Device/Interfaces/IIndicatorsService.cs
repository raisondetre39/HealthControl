using ControlSystem.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem.BL.Device.Interfaces
{
    public interface IIndicatorsService
    {
        Task<GetIndicatorsResult> GetIndicators();
    }
}
