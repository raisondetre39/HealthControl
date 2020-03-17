namespace ControlSystem.DAL.User.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        IDiseaseRepository DiseaseRepository { get; set; }
    }
}
