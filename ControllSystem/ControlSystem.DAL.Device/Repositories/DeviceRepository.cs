using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.Device.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IIndicatorRepository _indicatorRepository;

        public DeviceRepository(
            IUserRepository userRepository,
            IIndicatorRepository indicatorRepository)
        {
            _userRepository = userRepository;
            _indicatorRepository = indicatorRepository;
        }

        public async Task UpdateAsync(Contracts.Entities.Device entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<CreateDeviceResult> InsertAsync(Contracts.Entities.Device entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var isUserExists = await _userRepository.IsUserExist(entity.UserId);

                if (!isUserExists)
                    return new CreateDeviceResult() { Status = CreateDeviceStatus.UserNotExists };

                var isIndicatorsExists = await _indicatorRepository
                    .IsIndicatorsExist(entity.DeviceIndicators.Select(ind => ind.IndicatorId));

                if (!isIndicatorsExists)
                    return new CreateDeviceResult() { Status = CreateDeviceStatus.IndicatorNotExists };

                await context.AddAsync(entity);
                await context.SaveChangesAsync();

                return new CreateDeviceResult()
                {
                    Status = CreateDeviceStatus.Success,
                    DeviceId = entity.Id
                };
            }
        }

        public async Task<Contracts.Entities.Device> GetDeviceByAsync(Expression<Func<Contracts.Entities.Device, bool>> expression)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Devices.Include(device => device.DeviceIndicators)
                    .FirstOrDefaultAsync(expression);
            }
        }
    }
}
