using ControlSystem.DAL.Interfaces;

namespace ControlSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(
           IUserRepository userRepository)

        {
            UserRepository = userRepository;
        }
    }
}
