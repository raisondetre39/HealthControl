using ControlSystem.Contracts.Entities;
using ControlSystem.DAL.Device.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlSystem.DAL.Device.Repositories
{
    public class IndicatorRepository : IIndicatorRepository
    {
        public async Task<bool> IsIndicatorsExist(IEnumerable<int> indicators)
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                foreach(var indicator in indicators)
                {
                    var any = await context.Set<Indicator>()
                        .AnyAsync(s => s.Id == indicator);

                    if (!any)
                        return false;
                }

                return true;

            }
        }

        public async Task<IEnumerable<Indicator>> GetIndicators()
        {
            using (var context = new ControlSystemContext.ControlSystemContext())
            {
                return await context.Set<Indicator>()
                    .ToListAsync();
            }
        }
    }
}
