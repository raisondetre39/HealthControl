using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using ControlSystem.DAL.Device.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem.BL.Device.Services
{
    public class IndicatorValueService : IIndicatorValuesService
    {
        private readonly IIndicatorValuesRepository _indicatorValuesRepository;

        public IndicatorValueService(IIndicatorValuesRepository indicatorValuesRepository)
        {
            _indicatorValuesRepository = indicatorValuesRepository;
        }

        public async Task<AddIndicatorValueStatus> AddIndicatorValue(IndicatorValue indicatorValue)
        {
            return await _indicatorValuesRepository.InsertAsync(indicatorValue);
        }
    }
}
