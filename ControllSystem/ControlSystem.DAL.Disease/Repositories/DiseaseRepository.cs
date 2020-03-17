using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.Disease.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Disease.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        public async Task<IEnumerable<Contracts.Entities.Disease>> GetAsync()
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Diseases
                    .ToListAsync();
            }
        }

        public async Task<UpdateDiseaseStatus> UpdateAsync(Contracts.Entities.Disease entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var isUnique = await IsDiseaseNameUnique(entity.DiseaseName, 0);

                if (!isUnique)
                    return UpdateDiseaseStatus.NonUniqueName;

                context.Update(entity);
                await context.SaveChangesAsync();

                return UpdateDiseaseStatus.Success;
            }
        }

        public async Task<CreateDiseaseResult> InsertAsync(Contracts.Entities.Disease entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var isUnique = await IsDiseaseNameUnique(entity.DiseaseName, 0);

                if (!isUnique)
                    return new CreateDiseaseResult() { Status = CreateDiseaseStatus.NonUniqueName };

                await context.AddAsync(entity);
                await context.SaveChangesAsync();

                return new CreateDiseaseResult()
                {
                    Status = CreateDiseaseStatus.Success,
                    DiseaseId = entity.Id
                };
            }
        }

        public async Task<Contracts.Entities.Disease> GetDiseaseByAsync(Expression<Func<Contracts.Entities.Disease, bool>> expression)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Diseases
                    .FirstOrDefaultAsync(expression);
            }
        }

        private async Task<bool> IsDiseaseNameUnique(string name, int id = default(int))
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var disease = await context.Diseases.FirstOrDefaultAsync(t => t.DiseaseName == name);

                if (id != default(int) && disease != null)
                    return disease.Id == id;

                return disease == null;
            }
        }
    }
}
