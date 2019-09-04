using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Common
{
    public interface IVehicleMake : IVehicle
    {        
        IList<IVehicleModel> VehicleModels { get; set; }
    }
}
