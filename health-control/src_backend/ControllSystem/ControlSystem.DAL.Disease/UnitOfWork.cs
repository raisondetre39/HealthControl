using ControlSystem.DAL.Disease.Interfaces;

namespace ControlSystem.DAL.Disease
{
    public class UnitOfWork : IUnitOfWork
    {        
        public IDiseaseRepository DiseaseRepository { get; set; }

        public UnitOfWork(
           IDiseaseRepository diseaseRepository)

        {
            DiseaseRepository = diseaseRepository;
        }
    }
}
