using ControlSystem.DAL.Device.Interfaces;

namespace ControlSystem.DAL.Device
{
    public class UnitOfWork : IUnitOfWork
    {        
        public IDeviceRepository DeviceRepository { get; set; }

        public IUserRepository UserRepository { get; set; }

        public IIndicatorRepository IndicatorRepository { get; set; }

        public IIndicatorValuesRepository IndicatorValuesRepository { get; set; }

        public UnitOfWork(
           IDeviceRepository deviceRepository,
           IUserRepository userRepository,
           IIndicatorRepository indicatorRepository,
           IIndicatorValuesRepository indicatorValuesRepository)

        {
            DeviceRepository = deviceRepository;
            UserRepository = userRepository;
            IndicatorRepository = indicatorRepository;
            IndicatorValuesRepository = indicatorValuesRepository;
        }
    }
}
