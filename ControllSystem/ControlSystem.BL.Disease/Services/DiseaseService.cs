using ControlSystem.BL.Disease.Interfaces;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.Disease.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.BL.Disease.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IUnitOfWork unitOfWork)
        {
            _diseaseRepository = unitOfWork.DiseaseRepository;
        }

        public async Task<GetDiseasesResult> GetDiseases()
        {
            var result = await _diseaseRepository.GetAsync();
            return new GetDiseasesResult()
            {
                Diseases = result,
                Count = result.Count()
            };
        }

        public async Task<CreateDiseaseResult> CreateDisease(Contracts.Entities.Disease disease)
        {
            return await _diseaseRepository.InsertAsync(disease);
        }

        public async Task UpdateDisease(Contracts.Entities.Disease disease)
        {
            await _diseaseRepository.UpdateAsync(disease);
        }

        public async Task<Contracts.Entities.Disease> GetDiseaseBy(Expression<Func<Contracts.Entities.Disease, bool>> expression)
        {
            return await _diseaseRepository.GetDiseaseByAsync(expression);
        }
    }
}
