using ControlSystem.BL.Disease.Interfaces;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.Disease.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Contracts.Entities.Disease>> GetDiseases()
        {
            return await _diseaseRepository.GetAsync();
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
