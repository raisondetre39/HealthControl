using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Disease.Interfaces
{
    public interface IDiseaseRepository
    {
        Task<UpdateDiseaseStatus> UpdateAsync(Contracts.Entities.Disease entity);

        Task<CreateDiseaseResult> InsertAsync(Contracts.Entities.Disease entity);

        Task<Contracts.Entities.Disease> GetDiseaseByAsync(Expression<Func<Contracts.Entities.Disease, bool>> expression);

        Task<IEnumerable<Contracts.Entities.Disease>> GetAsync();
    }
}
