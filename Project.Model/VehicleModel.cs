using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model
{
    public class VehicleModel : Vehicle, IVehicleModel
    {
        public Guid VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
