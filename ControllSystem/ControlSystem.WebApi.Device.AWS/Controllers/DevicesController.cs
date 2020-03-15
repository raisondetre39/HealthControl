using AutoMapper;
using ControlSystem.BL.Device.Interfaces;
using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Requests;
using ControlSystem.WebApi.Device.AWS.Infrastructure.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ControlSystem.WebApi.Device.AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DevicesController(
            IDeviceService deviceService,
            IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]CreateDeviceRequest request)
        {
            if (request.UserId <= 0)
                return BadRequest("User id cann't be less or equal 0");

            if (!request.IndicatorIds.Any())
                return BadRequest("Device should have at list one minimum one indicator");

            var device = new Contracts.Entities.Device()
            {
                DeviceName = request.DeviceName,
                UserId = request.UserId,
                DeviceIndicators = request.IndicatorIds.Select(ind => new DeviceInicator() {IndicatorId = ind }).ToList()
            };

            var result = await _deviceService
                .CreateDevice(device);

            if (result.Status == CreateDeviceStatus.IndicatorNotExists)
                return NotFound($"Indicators not found");

            if (result.Status == CreateDeviceStatus.UserNotExists)
                return NotFound($"User with id: {request.UserId} not exist");

            return Created("DevicesController", result);
        }

        //[UserAuthorization]
        [HttpPut("{id}")]
        [ValidateModelState]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdateDeviceRequest request)
        {
            if (id <= default(int))
                return BadRequest("Id should be more then 0");

            var device = _mapper.Map<Contracts.Entities.Device>(request);
            device.Id = id;

            await _deviceService.UpdateDevice(device);

            return Ok();
        }

        //[UserAuthorization]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= default(int))
                return BadRequest("Id should be more then 0");

            var device = await _deviceService.GetDeviceBy(item => item.Id == id);

            if (device == null)
                return NotFound($"Device with id: {id} not found");

            return Ok(device);
        }
    }
}