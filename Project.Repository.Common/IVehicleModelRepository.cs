using Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> ListModelAsync();
        Task AddModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindModelByIdAsync(Guid id);
        Task UpdateModelAsync(VehicleModel vehicleModel);
        Task RemoveModelAsync(VehicleModel vehicleModel);
    }
}
