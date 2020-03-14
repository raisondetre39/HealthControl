using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlSystem.BL.Device.Interfaces;
using ControlSystem.Contracts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlSystem.WebApi.Device.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsController : ControllerBase
    {
        private readonly IIndicatorsService _indicatorsService;

        public IndicatorsController(IIndicatorsService indicatorsService)
        {
            _indicatorsService = indicatorsService;
        }

        [HttpGet]
        public async Task<GetIndicatorsResult> GetIndicators()
        {
            return await _indicatorsService.GetIndicators();
        }
    }
}