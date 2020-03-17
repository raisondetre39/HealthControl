using ControlSystem.DAL.User.Interfaces;

namespace ControlSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {        
        public IUserRepository UserRepository { get; set; }

        public IDiseaseRepository DiseaseRepository { get; set; }

        public UnitOfWork(
           IUserRepository userRepository,
           IDiseaseRepository diseaseRepository)

        {
            UserRepository = userRepository;
            DiseaseRepository = diseaseRepository;
        }
    }
}
