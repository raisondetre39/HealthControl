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
                var user = await _userRepository.IsUserExist(entity.UserId);

                if (user == null)
                    return new CreateDeviceResult() { Status = CreateDeviceStatus.UserNotExists };

                var isIndicatorsExists = await _indicatorRepository
                    .IsIndicatorsExist(entity.DeviceIndicators.Select(ind => ind.IndicatorId));

                if (!isIndicatorsExists)
                    return new CreateDeviceResult() { Status = CreateDeviceStatus.IndicatorNotExists };

                await context.AddAsync(entity);

                user.DeviceId = entity.Id;
                context.Update(user);
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
                var device =  await context.Devices.Include(item => item.DeviceIndicators)
                    .FirstOrDefaultAsync(expression);

                device.DeviceIndicators
                    .ForEach(ind => ind.IndicatorValues =  context.Set<IndicatorValue>()
                        .Where(item => item.DeviceIndicatorId == ind.Id).ToList());

                return device;
            }
        }
    }
}
