using Project.Common;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListAllAsync();
        Task<VehicleModel> FindModelAsync(Guid id);
        Task<VehicleResponse<VehicleModel>> SaveAsync(VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> UpdateAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> DeleteAsync(Guid id);

    }
}
