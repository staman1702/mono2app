using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Common
{
    public interface IVehicleModel : IVehicle
    {        
        Guid VehicleMakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
