using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.API.Resources;
using Project.Service.Common;
using Project.API.Extensions;


namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleModelResource>), 200)]
        public async Task<IEnumerable<VehicleModelResource>> ListAsync()
        {
            var vehicleModels = await _vehicleModelService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelResource>>(vehicleModels);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVehicleModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vehicleModel = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
            var result = await _vehicleModelService.SaveAsync(vehicleModel);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.Response);
            return Ok(vehicleModelResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveVehicleModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
            var result = await _vehicleModelService.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.Response);
            return Ok(vehicleModelResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _vehicleModelService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelService = _mapper.Map<VehicleModel, VehicleModelResource>(result.Response);
            return Ok(vehicleModelService);
        }
    }
}