using AutoMapper;
using ControlSystem.BL.User.Interfaces;
using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Models;
using ControlSystem.WebApi.User.AWS.Infrastructure.Security;
using ControlSystem.WebApi.User.AWS.Infrastructure.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlSystem.WebApi.User.AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]CreateUserRequest request)
        {
            if (request.DiseaseId <= 0)
                return BadRequest("Disease id cann't be less or equal 0");

            var result = await _userService
                .CreateUser(_mapper.Map<Contracts.Entities.User>(request));

            if (result.Status == CreateUserStatus.DiseaseNotExists)
                return NotFound($"Disease with id: {request.DiseaseId} not found");

            if (result.Status == CreateUserStatus.NonUniqueEmail)
                return BadRequest($"User with email: {request.Email} already exists");

            return Created("UserController", result);
        }

        [UserAuthorization]
        [HttpPut("{id}")]
        [ValidateModelState]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]UpdateUserRequest request)
        {
            var user = _mapper.Map<Contracts.Entities.User>(request);
            user.Id = id;

            var result = await _userService.UpdateUser(user);

            if (result == UpdateUserStatus.NonUniqueEmail)
                return BadRequest($"User with email: {request.Email} already exists");

            return Ok();
        }

        [UserAuthorization]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= default(int))
                return BadRequest("Id should be more then 0");

            var user = await _userService.GetUserBy(item => item.Id == id);

            if (user == null)
                return NotFound($"User with id: {id} not found");

            return Ok(user);
        }

        [UserAuthorization]
        [HttpGet]
        public async Task<IEnumerable<Contracts.Entities.User>> GetUsers(int id)
        {
            return await _userService.GetUsers();
        }

        [UserAuthorization]
        [HttpDelete("{id}")]
        [ValidateModelState]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= default(int))
                return BadRequest("Id should be more then 0");

            await _userService.DeleteUser(id);
            
            return Ok();
        }
    }
}