using Project.Model.Common;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class VehicleMake : Vehicle, IVehicleMake
    {
        public IList<IVehicleModel> VehicleModels { get; set; } = new List<IVehicleModel>();
    }
}
