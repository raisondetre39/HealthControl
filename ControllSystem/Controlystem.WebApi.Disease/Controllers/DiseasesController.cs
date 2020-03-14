using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.ElasticFileSystem.Model;
using ControlSystem.BL.Disease.Interfaces;
using ControlSystem.Contracts.Enums;
using ControlSystem.Contracts.Responses;
using ControlSystem.WebApi.Disease.Infrastructure.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Controlystem.WebApi.Disease.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseasesController(
            IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IEnumerable<ControlSystem.Contracts.Entities.Disease>> Get()
        {
            return await _diseaseService.GetDiseases();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]string diseaseName)
        {
            if (string.IsNullOrWhiteSpace(diseaseName))
                return BadRequest("Disease name cann't be empty");

            var result = await _diseaseService
                .CreateDisease(new ControlSystem.Contracts.Entities.Disease() { DiseaseName = diseaseName });

            if (result.Status == CreateDiseaseStatus.NonUniqueName)
                return BadRequest($"Disease with name: {diseaseName} already exists");

            return Ok(result);
        }

        //[UserAuthorization]
        [HttpPut("{id}")]
        [ValidateModelState]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]string diseaseName)
        {
            if (id <= default(int))
                return BadRequest("Id should be more then 0");

            await _diseaseService
                .UpdateDisease(new ControlSystem.Contracts.Entities.Disease() {Id = id, DiseaseName = diseaseName });

            return Ok();
        }

        //[UserAuthorization]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= default(int))
                return BadRequest("Id should be more then 0");

            var disease = await _diseaseService.GetDiseaseBy(item => item.Id == id);

            if (disease == null)
                return NotFound($"Disease with id: {id} not found");

            return Ok(disease);
        }
    }
}
