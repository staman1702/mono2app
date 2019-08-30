using Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> ListMakeAsync();
        Task AddMakeAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindMakeByIdAsync(Guid id);
        Task UpdateMakeAsync(VehicleMake vehicleMake);
        Task DeleteMakeAsync(VehicleMake vehicleMake);
    }
}
