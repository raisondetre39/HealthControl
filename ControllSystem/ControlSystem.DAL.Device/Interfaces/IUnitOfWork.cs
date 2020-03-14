namespace ControlSystem.DAL.Device.Interfaces
{
    public interface IUnitOfWork
    {
        IDeviceRepository DeviceRepository { get; set; }

        IUserRepository UserRepository { get; set; }

        IIndicatorRepository IndicatorRepository { get; set; }

        IIndicatorValuesRepository IndicatorValuesRepository { get; set; }
    }
}
