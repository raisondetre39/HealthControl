using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.User.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlSystem.DAL.User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDiseaseRepository _diseaseRepository;
        public UserRepository(
            IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public async Task<UpdateUserStatus> UpdateAsync(Contracts.Entities.User entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var isUnique = await IsUserEmailUnique(entity.Email, entity.Id);

                if (!isUnique)
                    return  UpdateUserStatus.NonUniqueEmail;

                context.Update(entity);
                await context.SaveChangesAsync();

                return UpdateUserStatus.Success;
            }
        }

        public async Task<CreateUserResponse> InsertAsync(Contracts.Entities.User entity)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                entity.Role = 0;
                var isUnique = await IsUserEmailUnique(entity.Email, 0);

                if (!isUnique)
                    return new CreateUserResponse() { Status = CreateUserStatus.NonUniqueEmail };

                var isExists = await _diseaseRepository.IsDiseaseExist(entity.DiseaseId.Value);

                if (!isExists)
                    return new CreateUserResponse() { Status = CreateUserStatus.DiseaseNotExists };

                await context.AddAsync(entity);
                await context.SaveChangesAsync();

                return new CreateUserResponse()
                {
                    Status = CreateUserStatus.Success,
                    UserId = entity.Id
                };
            }
        }

        public async Task<Contracts.Entities.User> GetUserByAsync(Expression<Func<Contracts.Entities.User, bool>> expression)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Users.Include(user => user.Disease)
                    .FirstOrDefaultAsync(expression);
            }
        }

        private async Task<bool> IsUserEmailUnique(string email, int id = default(int))
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.Email == email);

                if (id != default(int) && user != null)
                    return user.Id == id;

                return user == null;
            }
        }

        public async Task<IEnumerable<Contracts.Entities.User>> GetAsync()
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Users
                    .ToListAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(item => item.Id == id);

                if (user != null)
                    context.Users.Remove(user);
            }
        }
    }
}
