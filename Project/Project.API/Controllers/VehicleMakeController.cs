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
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleMakeResource>), 200)]
        public async Task<IEnumerable<VehicleMakeResource>> ListAsync()
        {
            var vehicleMakes = await _vehicleMakeService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeResource>>(vehicleMakes);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVehicleMakeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vehicleMake = _mapper.Map<SaveVehicleMakeResource, VehicleMake>(resource);
            var result = await _vehicleMakeService.SaveAsync(vehicleMake);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.Response);
            return Ok(vehicleMakeResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveVehicleMakeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var make = _mapper.Map<SaveVehicleMakeResource, VehicleMake>(resource);
            var result = await _vehicleMakeService.UpdateAsync(id, make);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.Response);
            return Ok(vehicleMakeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _vehicleMakeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.Response);
            return Ok(vehicleMakeResource);
        }
    }
}
