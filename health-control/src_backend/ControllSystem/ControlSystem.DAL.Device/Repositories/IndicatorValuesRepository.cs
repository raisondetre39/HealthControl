using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using ControlSystem.DAL.Device.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Repositories
{
    public class IndicatorValuesRepository : IIndicatorValuesRepository
    {
        public async Task<AddIndicatorValueStatus> InsertAsync(IndicatorValue entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var isExists = await IsDeviceIndicatorExist(entity.DeviceIndicatorId);

                if (!isExists)
                    return AddIndicatorValueStatus.DeviceIndicatorNotExists;

                await context.AddAsync(entity);
                await context.SaveChangesAsync();

                return AddIndicatorValueStatus.Success;
            }
        }

        public async Task<bool> IsDeviceIndicatorExist(int deviceIndicatorId)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Set<DeviceInicator>()
                        .AnyAsync(s => s.Id == deviceIndicatorId);
            }
        }
    }
}
