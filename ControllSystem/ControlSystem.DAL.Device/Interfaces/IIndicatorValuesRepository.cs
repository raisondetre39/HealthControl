using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IIndicatorValuesRepository
    {
        Task<AddIndicatorValueStatus> InsertAsync(IndicatorValue entity);

        Task<bool> IsDeviceIndicatorExist(int deviceIndicatorId);
    }
}
