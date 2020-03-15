using ControlSystem.BL.Device.Interfaces;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.Device.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem.BL.Device.Services
{
    public class IndicatorService : IIndicatorsService
    {
        private readonly IIndicatorRepository _indicatorRepository;

        public IndicatorService(IUnitOfWork unitOfWork)
        {
            _indicatorRepository = unitOfWork.IndicatorRepository;
        }

        public async Task<GetIndicatorsResult> GetIndicators()
        {
            var result = await _indicatorRepository.GetIndicators();

            return new GetIndicatorsResult()
            {
                Indicators = result,
                Count = result.Count()
            };
        }
    }
}
