using Project.Common;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> ListAllAsync();
        Task<VehicleMake> FindMakeAsync(Guid id);
        Task<VehicleResponse<VehicleMake>> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> DeleteAsync(Guid id);

    }
}
