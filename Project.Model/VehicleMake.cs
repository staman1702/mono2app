using Project.Model.Common;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class VehicleMake : Vehicle
    {
        public IList<VehicleModel> VehicleModels { get; set; } = new List<VehicleModel>();
    }
}
