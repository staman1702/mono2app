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
    public class VehicleMakeRepository : BaseRepository, IVehicleMakeRepository
    {
        private readonly IMapper _mapper;

        public VehicleMakeRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleMake>> ListMakeAsync()
        {
            return _mapper.Map<IEnumerable<MakeEntity>, IEnumerable<VehicleMake>>
                (await _context.VehicleMakes.ToListAsync());
        }

        public async Task AddMakeAsync(VehicleMake vehicleMake)
        {          
            await _context.VehicleMakes.AddAsync(_mapper.Map<VehicleMake, MakeEntity>
                (vehicleMake));
        }

        public async Task<VehicleMake> FindMakeByIdAsync(Guid id)
        {
            return _mapper.Map<MakeEntity, VehicleMake>
               (await _context.VehicleMakes.FindAsync(id));
        }

        public async Task UpdateMakeAsync(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Update(_mapper.Map<VehicleMake, MakeEntity>
                (vehicleMake));
            await _context.SaveChangesAsync();

        }

        public async Task DeleteMakeAsync(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Remove(_mapper.Map<VehicleMake, MakeEntity>
                (vehicleMake));
            await _context.SaveChangesAsync();

        }

    }
}