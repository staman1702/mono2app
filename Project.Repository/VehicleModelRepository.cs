using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<VehicleModel>> ListModelAsync()
        {
            return await _context.VehicleModels.Include(p => p.VehicleMake).ToListAsync();
        }

        public async Task AddModelAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(vehicleModel);
        }

        public async Task<VehicleModel> FindModelByIdAsync(Guid id)
        {
            return await _context.VehicleModels.FindAsync(id);
        }

        public async Task UpdateModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
            await _context.SaveChangesAsync();
        }

    }
}
