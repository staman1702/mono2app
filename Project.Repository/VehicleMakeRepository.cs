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
    public class VehicleMakeRepository : BaseRepository, IVehicleMakeRepository
    {
        public VehicleMakeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<VehicleMake>> ListMakeAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }

        public async Task AddMakeAsync(VehicleMake vehicleMake)
        {
            await _context.VehicleMakes.AddAsync(vehicleMake);
        }

        public async Task<VehicleMake> FindMakeByIdAsync(Guid id)
        {
            return await _context.VehicleMakes.FindAsync(id);
        }

        public async Task UpdateMakeAsync(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Update(vehicleMake);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteMakeAsync(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Remove(vehicleMake);
            await _context.SaveChangesAsync();

        }

    }
}