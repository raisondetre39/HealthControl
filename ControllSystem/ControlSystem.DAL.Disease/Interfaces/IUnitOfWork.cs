namespace ControlSystem.DAL.Disease.Interfaces
{
    public interface IUnitOfWork
    {
        IDiseaseRepository DiseaseRepository { get; set; }
    }
}
