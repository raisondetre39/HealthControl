namespace ControlSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
    }
}
