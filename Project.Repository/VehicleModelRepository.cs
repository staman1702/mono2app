using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        private readonly IMapper _mapper;

        public VehicleModelRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleModel>> ListModelAsync()
        {
            return _mapper.Map<IEnumerable<ModelEntity>, IEnumerable<VehicleModel>>
                (await _context.VehicleModels.Include(p => p.VehicleMake).ToListAsync());

        }

        public async Task AddModelAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(_mapper.Map<VehicleModel, ModelEntity>
                (vehicleModel));
        }

        public async Task<VehicleModel> FindModelByIdAsync(Guid id)
        {
            return _mapper.Map<ModelEntity, VehicleModel>
               (await _context.VehicleModels.FindAsync(id));
        }

        public async Task UpdateModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(_mapper.Map<VehicleModel, ModelEntity> 
                (vehicleModel));
            await _context.SaveChangesAsync();
        }

        public async Task RemoveModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(_mapper.Map<VehicleModel, ModelEntity>
                (vehicleModel));
            await _context.SaveChangesAsync();
        }

    }
}
