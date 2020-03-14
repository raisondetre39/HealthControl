using ControlSystem.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.BL.Disease.Interfaces
{
    public interface IDiseaseService
    {
        Task<GetDiseasesResult> GetDiseases();

        Task<CreateDiseaseResult> CreateDisease(Contracts.Entities.Disease disease);

        Task UpdateDisease(Contracts.Entities.Disease disease);

        Task<Contracts.Entities.Disease> GetDiseaseBy(Expression<Func<Contracts.Entities.Disease, bool>> expression);
    }
}
